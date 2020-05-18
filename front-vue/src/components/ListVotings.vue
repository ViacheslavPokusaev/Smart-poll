<template>
  <div id="listvotings" v-if="User.TypeVoting == 'private'">
    <div class="myclass" v-for="(Voting) in Votings" :key="Voting.index">
      <VotingPrivate :CurrentVoting="Voting" :User="User" v-on:Delete-Voting="DeleteVoting" />
    </div>
  </div>
  <div id="listvotings" v-else>
    <div class="myclass" v-for="(Voting) in Votings" :key="Voting.index">
      <OneVoting :CurrentVoting="Voting" :User="User" />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import OneVoting from "@/components/Voting.vue";
import VotingPrivate from "@/components/VotingPrivate.vue";

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
        delete: "http://localhost:5001/voting/delete"
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
      axios.get(this.url.privateVot + `${this.User.UserID}`).then(response => {
        console.log(`${this.User.UserID}`);
        this.Votings = response.data[0];
      });
    }
  },
  methods: {
    DeleteVoting(VotingID, TypeVoting) {
      console.log(VotingID);
      axios.post(this.url.delete, { VotingID: VotingID }).then(() => this.UpdateList).catch(error => {
        alert("Невозможно удалить голосование!");
      });
      this.update = TypeVoting;
    }
  },
  components: {
    OneVoting,
    VotingPrivate
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