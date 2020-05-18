<template>
  <div id="voting">
    <strong>{{CurrentVoting.questionInVoting}}</strong>
    <div v-for="(properties) in CurrentVoting.options" :key="properties.index" id="VotOptions">
      <input type="checkbox" v-bind:id="properties.optionID" v-on:change="CheckAnswers" />
      <label>{{properties.nameOption}}</label>
    </div>
    <input type="text" v-model="NewOption" v-if="CurrentVoting.addNewOptions" />
    <button
      v-if="CurrentVoting.addNewOptions"
      v-bind:id="CurrentVoting.votingID"
      @click="$emit('Add-Option', AddOption(), CurrentVoting.votingID, 'active')"
    >+ вариант</button>
    <button
      v-bind:id="CurrentVoting.votingID"
      @click="$emit('Add-Answer', Vote(), CurrentVoting.votingID, 'active')"
    >Проголосовать</button>
    Автор - {{CurrentVoting.userName}}
    <br />
    <strong v-if="User.TypeVoting != 'deadline'">Конец голосования - {{TimeLeft}}</strong>
    <strong v-else id="STOP">Это голосование оконченно!</strong>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentVoting", "User"],
  name: "Voting",
  data() {
    return {
      NewOption: "",
      CurrentDeadLine: null,
      AllUserAnswers: 0,
      ChosenOptions: []
    };
  },
  computed: {
    TimeLeft() {
      return this.CurrentDeadLine;
    }
  },
  mounted: function() {
    if (this.User.TypeVoting != "deadline")
      setInterval(() => this.GetData(), 1000);
    else {
      this.Block();
    }
  },
  methods: {
    Vote: function() {
      let i = 0;
      let UserVot = 0;
      if (this.CurrentVoting.userAnswers.length > 0) {
        for (let OneUsersAnswers of this.CurrentVoting.userAnswers) {
          for (let UserAnswer in OneUsersAnswers) {
            if (UserAnswer == "optionID") {
              for (let options of this.ChosenOptions) {
                if (OneUsersAnswers[UserAnswer] == options) i++;
              }
            }
            if (UserAnswer == "userID") {
							UserVot = OneUsersAnswers[UserAnswer];
              if (
                OneUsersAnswers[UserAnswer] == this.User.UserID &&
                this.CurrentVoting.maxVotesByOneUser > 1
              )
                i++;
              else if (UserVot == this.User.UserID) {
                alert("Вы уже приняли участие в этом голосовании");
                return "";
              }
            }
          }
        }
        if (i == 2) {
          alert("Вы уже голосовали за это");
          return "";
        } else {
          console.log("Добавляем ответ!");
          return this.ChosenOptions;
        }
      } else {
        console.log("Добавляем ответ!");
        return this.ChosenOptions;
      }
    },
    AddOption: function() {
      let CheckOptions = this.CurrentVoting.options.length;
      if (CheckOptions + 1 > this.CurrentVoting.maxOptions) {
        alert("Достигнут лимит вариантов");
        return "";
      } else {
        let option = this.NewOption;
        this.NewOption = "";
        return option;
      }
    },
    GetData: function() {
      let DataDeadLine = new Date(Date.parse(this.CurrentVoting.deadLine));
      let Millis = DataDeadLine - Date.now();

      let days = Millis / (1000 * 60 * 60 * 24);
      let absoluteDays = Math.floor(days);
      let d = absoluteDays > 9 ? absoluteDays : "0" + absoluteDays;

      let hours = (days - absoluteDays) * 24; //Millis / (1000 * 60 * 60);
      let absoluteHours = Math.floor(hours);
      let h = absoluteHours > 9 ? absoluteHours : "0" + absoluteHours;

      //Get remainder from hours and convert to minutes
      let minutes = (hours - absoluteHours) * 60;
      let absoluteMinutes = Math.floor(minutes);
      let m = absoluteMinutes > 9 ? absoluteMinutes : "0" + absoluteMinutes;

      //Get remainder from minutes and convert to seconds
      let seconds = (minutes - absoluteMinutes) * 60;
      let absoluteSeconds = Math.floor(seconds);
      let s = absoluteSeconds > 9 ? absoluteSeconds : "0" + absoluteSeconds;

      this.CurrentDeadLine = d + ":" + h + ":" + m + ":" + s;
    },
    Block: function() {
      let elements = document.getElementById("voting");
      for (let elem of elements.children) {
        if (elem.id == "VotOptions")
          for (let opt of elem.children) {
            opt.disabled = true;
          }
        elem.disabled = true;
      }
    },
    CheckAnswers: function(event) {
      let Option = event.target;

      if (this.CurrentVoting.maxVotesByOneUser == 1) {
        if (Option.checked === true) this.ChosenOptions.unshift(Option.id);
        else this.ChosenOptions.pop();
        if (this.ChosenOptions.length > 1)
          document.getElementById(this.ChosenOptions.pop()).checked = false;
      } else {
        if (Option.checked === false) {
          this.ChosenOptions.splice(
            this.ChosenOptions.indexOf(Option.id) - 1,
            1
          );
        } else {
          this.ChosenOptions.push(Option.id);
          if (
            this.ChosenOptions.length > this.CurrentVoting.maxVotesByOneUser
          ) {
            Option.checked = true;
            this.ChosenOptions.pop();
            document.getElementById(this.ChosenOptions.pop()).checked = false;
            this.ChosenOptions.push(Option.id);
          }
        }
      }
    }
  }
};
</script>

<style scoped>
button {
  background: aqua;
  border: 1px solid black;
  border-radius: 5px;
}

#STOP {
  background: red;
}
</style>