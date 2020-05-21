<template>
  <div id="listvotings" v-if="User.TypeVoting == 'private'">
    <div class="myclass" v-for="(Voting) in Votings" :key="Voting.index">
      <VotingPrivate
        :CurrentVoting="Voting"
        :User="User"       
        v-on:Update-Voting="UpdateVoting"
      />
    </div>
    <div id="AddVoting">
      <input type="text" placeholder="Введите вопрос" v-model="NewVoting.QuestionInVoting" />
      <input type="text" placeholder="Введите количество вариантов" v-model="NewVoting.MaxOptions" />
      <input
        type="text"
        placeholder="Введите сколько можно проголосовать за 1 раз"
        v-model="NewVoting.MaxVotesByOneUser"
      />
      <input type="text" placeholder="Введите время конца голосования" v-model="NewVoting.DeadLine" />
      <input
        type="checkbox"
        placeholder="Добавление новых вариантов"
        id="AddNewOpt"
        v-model="NewVoting.AddNewOptions"
      />
      <label for="jack">Добавление новых вариантов</label>

      <button @click="AddVoting">Добавить голосование</button>
    </div>
  </div>
  <div id="listvotings" v-else-if="User.TypeVoting == 'uservotings'">
    <div class="myclass" v-for="(Voting) in Votings" :key="Voting.index">
      <MyVoting :CurrentVoting="Voting" :User="User" v-on:Delete-Voting="DeleteVoting" />
    </div>
  </div>
  <div id="listvotings" v-else>
    <div class="myclass" v-for="(Voting) in Votings" :key="Voting.index">
      <OneVoting
        :CurrentVoting="Voting"
        :User="User"
        v-on:Add-Option="AddOption"
        v-on:Add-Answer="AddAnswer"
      />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import OneVoting from "@/components/Voting.vue";
import VotingPrivate from "@/components/VotingPrivate.vue";
import MyVoting from "@/components/MyVoting.vue";

export default {
  props: ["User"],
  name: "ListVotings",
  data() {
    return {
      update: "notdelete",
      Votings: {},
      url: {
        active: "http://localhost:5001/voting/common/public",
        privateVot: "http://localhost:5001/voting/privatevotings/", // need UserID
        deadline: "http://localhost:5001/voting/common/deadline",
        uservotings: "http://localhost:5001/voting/uservotings/", // need UserID
        delete: "http://localhost:5001/voting/delete",
        options: "http://localhost:5001/options",
        update: "http://localhost:5001/voting/update",
        add: "http://localhost:5001/voting",
        addAnswer: "http://localhost:5001/useranswer",
        addOpt: "http://localhost:5001/options"
      },
      NewVoting: {
        UserID: this.User.UserID,
        AddNewOptions: false,
        MaxOptions: 19,
        MaxVotesByOneUser: 1,
        QuestionInVoting: "НЕЗАДАНО",
        DeadLine: "2020-06-21",
        PublicOrPrivate: true
      }
    };
  },
  computed: {
    UpdateList: function() {
      if (this.update !== "notdelete") {
        if (this.update === "private") {
          axios
            .get(this.url.privateVot + `${this.User.UserID}`)
            .then(response => {
              console.log(`${this.User.UserID}`);
              this.Votings = response.data[0];
            });
        } else if (this.update === "active") {
          axios;
          axios.get(this.url.active).then(response => {
            this.Votings = response.data[0];
          });
        } else {
          axios
            .get(this.url.uservotings + `${this.User.UserID}`)
            .then(response => {
              console.log(`${this.User.UserID}`);
              this.Votings = response.data[0];
            });
        }
      }
    }
  },
  mounted: function() {
    if (this.User.TypeVoting === "active") {
      axios.get(this.url.active).then(response => {
        this.Votings = response.data[0];
      });
    } else if (this.User.TypeVoting === "deadline") {
      axios.get(this.url.deadline).then(response => {
        this.Votings = response.data[0];
      });
    } else if (this.User.TypeVoting === "private") {
      axios.get(this.url.privateVot + `${this.User.UserID}`).then(response => {
        console.log(`${this.User.UserID}`);
        this.Votings = response.data[0];
      });
    } else if (this.User.TypeVoting === "uservotings") {
      axios.get(this.url.uservotings + `${this.User.UserID}`).then(response => {
        console.log(`${this.User.UserID}`);
        this.Votings = response.data[0];
      });
    }
  },
  methods: {
    AddAnswer: function(chosenOptions, TypeVoting) {
      if (chosenOptions != "") {
        for (let Option of chosenOptions) {
          axios
            .post(this.url.addAnswer, {
              OptionID: Number(Option),
              UserID: Number(this.User.UserID)
            })
            .then((this.update = "active"))
            .then(alert("Вы успешно проголосовали"))
            .then(() => this.UpdateList);
        }
      }
    },
    AddOption: function(option, VotingID, TypeVoting) {
      if (option != "")
        axios
          .post(this.url.addOpt, {
            VotingID: VotingID,
            NameOption: option
          })
          .then(response => {
            this.update = "active";
            alert("Вариант успешно добавлен!");
          })
          .then(() => this.UpdateList);
    },
    AddVoting: function() {
      if (
        this.NewVoting.AddNewOptionsMaxOptions > 20 ||
        this.NewVoting.AddNewOptionsMaxVotesByOneUser < 1 ||
        this.NewVoting.AddNewOptionsMaxVotesByOneUser >
          this.NewVoting.AddNewOptionsMaxOptions ||
        this.NewVoting.AddNewOptionsQuestionInVoting === "" ||
        this.NewVoting.AddNewOptionsDeadLine === ""
      ) {
        alert("Неверно заполненные данные!");
      } else {
				this.NewVoting.UserID = this.User.UserID;
				console.log(this.NewVoting);
        axios
          .post(this.url.add, this.NewVoting)
          .then(response => {
            this.NewVoting.VotingID = response.data;
            this.update = "private";
            alert("Голосовалка успешно добавлена!");
          })
          .then(() => this.UpdateList);
      }
    },
    DeleteVoting(VotingID, TypeVoting) {
      axios
        .post(this.url.delete, { VotingID: VotingID })
        .then(() => this.UpdateList)
        .catch(error => {
          alert("Невозможно удалить голосование!");
        });
      this.update = TypeVoting;
    },
    UpdateVoting(Voting, CountOpt, TypeVoting) {
      if (CountOpt != 0) {
        for (let Option of Voting.Options) {
          axios
            .post(this.url.options, {
              VotingID: Voting.VotingID,
              NameOption: Option
            })
            .catch(error => {
              alert("Невозможно добавить варианты!");
            });
        }

        delete Voting.Options;

        axios
          .post(this.url.update, Voting)
          .then(() => this.UpdateList)
          .catch(error => {
            alert(error.message);
          });
        this.update = TypeVoting;
      } else {
        alert("Должен быть хотя бы 1 вариант!");
      }
    }
  },
  components: {
    OneVoting,
    VotingPrivate,
    MyVoting
  }
};
</script>

<style scoped>
div {
  flex: 300px;
  margin: 5px 5px 5px 5px;
  /*background-color: white;*/
}

#listvotings {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;

  padding: 5px 5px 5px 5px;
}

.myclass {
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;

  flex-basis: 250px;

  min-height: 250px;
  max-width: 250px;
}
</style>