<template>
  <div id="poll" class="myclass1">
    <strong>Текст вопроса</strong>
    <input type="text" id="question" v-model="CurrentPoll.questionText" />
    <strong>Варианты</strong>
    <div class="options" v-for="(properties, index) in CurrentPoll.optionsPoll" :key="index">
      <input type="text" class="option" v-model="properties.textOption" />
      <button :id="index" @click="DeleteOption">&#10008;</button>
    </div>
    <input type="text" v-model="textOption" placeholder="Enter text new option" />
    <button @click="AddOption">+ вариант</button>
    <strong id="othersettings">Технические параметры</strong>
    Максимум вариантов
    <input
      type="text"
      v-model.number="CurrentPoll.maxOptionsInPoll"
      @blur="CheckMaxOptions"
    />
    Максимум голосов 1 юзером
    <input
      type="text"
      v-model.number="CurrentPoll.maxVotesByOneClient"
      @blur="CheckMaxVotes"
    />
    Конец голосования
    <input type="text" v-model="CurrentPoll.deadLine" />
    <br />
    <div>
      <input type="checkbox" v-model="CurrentPoll.isPossibleToAddOption" id="isPossibleToAddOption" />
      <label for="isPossibleToAddOption">Возможность добавить вариант</label>
    </div>
    <div>
      <input type="checkbox" v-model="CurrentPoll.isPrivate" id="isPrivate" />
      <label for="isPrivate">Оставить приватным?</label>
    </div>
    <br />
    <button @click="$emit('Save-Changes', SaveChanges(), index)">Сохранить изменения</button>
    <button @click="$emit('Delete-Poll', CurrentPoll.id, index)">Удалить опрос</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentPoll", "Id", "index"],
  name: "PollPrivate",
  data() {
    return {
      textOption: ""
    };
  },
  created: function() {
    this.CurrentPoll.deadLine = this.CurrentPoll.deadLine.substring(0, 10);
    this.CurrentPoll.deadLine.replace("-", "/");
  },
  methods: {
    AddOption: function() {
      console.log(this.$route.params.Url.AddOption);
      if (this.CurrentPoll.optionsPoll == null)
        this.CurrentPoll.optionsPoll = [];
      if (this.textOption == "") alert("Вы не ввели текст нового варианта!");
      else {
        axios
          .post(this.$route.params.Url.AddOption, {
            PollId: this.CurrentPoll.id,
            TextOption: this.textOption
          })
          .then(response => {
            this.CurrentPoll.optionsPoll.push(response.data);
          });

        this.textOption = "";
      }
    },
    DeleteOption: function(event) {
      console.log(event.target.id);
      console.log(this.CurrentPoll.optionsPoll[event.target.id].id);

      axios
        .post(
          this.$route.params.Url.DeleteOption +
            `${this.CurrentPoll.optionsPoll[event.target.id].id}`,
          {
            Id: this.CurrentPoll.optionsPoll[event.target.id].id
          }
        )
        .catch(error => console.log(error));
      this.CurrentPoll.optionsPoll.splice(event.target.id, 1);
    },
    CheckMaxVotes: function() {
      if (
        this.CurrentPoll.maxVotesByOneClient >
          this.CurrentPoll.maxOptionsInPoll &&
        this.CurrentPoll.maxOptionsInPoll != 0
      ) {
        this.CurrentPoll.maxVotesByOneClient = null;
        alert(
          "Число вариантов клиента должно быть меньше количества всех вариантов!"
        );
      }
    },
    CheckMaxOptions: function() {
      if (this.CurrentPoll.maxOptionsInPoll > 19) {
        this.CurrentPoll.maxOptionsInPoll = 19;
        alert("Число вариантов не должно быть больше 19!");
      }
    },
    SaveChanges: function() {
      axios.post(this.$route.params.Url.Update, {
        QuestionText: this.CurrentPoll.questionText,
        DeadLine: this.CurrentPoll.deadLine,
        IsPrivate: this.CurrentPoll.isPrivate,
        MaxVotesByOneClient: this.CurrentPoll.maxVotesByOneClient,
        MaxOptionsInPoll: this.CurrentPoll.maxOptionsInPoll,
        IsPossibleToAddOption: this.CurrentPoll.isPossibleToAddOption,
        Id: this.CurrentPoll.id
      });
      return this.CurrentPoll.isPrivate;
    }
  }
};
</script>

<style scoped>
#poll {
  display: flex;
  flex-direction: column;
  font: 16px "Oswald", sans-serif;
}

.options {
  display: flex;
  justify-content: center;
  align-items: center;
}

.myclass1 {
  display: flex;
  flex-direction: column;
  margin: 5px 5px 5px 5px;
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;
  justify-content: center;
  width: 250px;
}

.option {
  width: 100%;
}

button {
  font: 16px "Oswald", sans-serif;
  background: aqua;
  border: 1px solid black;
  border-radius: 5px;
  margin-top: 10px;
}

strong {
  text-align: center;
}

#question {
  margin-bottom: 10px;
}

#othersettings {
  margin-bottom: 10px;
  margin-top: 10px;
}

input[type="text"] {
  margin-top: 5px;
}
</style>