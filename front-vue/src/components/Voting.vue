<template>
  <div id="voting">
    <strong>{{CurrentVoting.questionInVoting}}</strong>
    <div v-for="(properties) in CurrentVoting.options" :key="properties.index" id="VotOptions">
      <input type="checkbox" v-bind:id="properties.optionID" v-on:change="CheckAnswers" />
      <label>{{properties.nameOption}}</label>
    </div>
    <button v-if="CurrentVoting.addNewOptions" v-bind:id="CurrentVoting.votingID">+ вариант</button>
    <button v-bind:id="CurrentVoting.votingID">Проголосовать</button>
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
    console.log(this.User.TypeVoting);
    if (this.User.TypeVoting != "deadline")
      setInterval(() => this.GetData(), 1000);
    else {
      this.Block();
    }
  },
  methods: {
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
          console.log(elem);
          if (elem.id == "VotOptions")
            for (let opt of elem.children) {
              console.log(opt);
              opt.disabled = true;
            }
          elem.disabled = true;
      }
    },
    CheckAnswers: function(event) {
      let Option = event.target;

      if (this.CurrentVoting.maxVotesByOneUser == 1) {
        this.ChosenOptions.unshift(Option.id);
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
            console.log(this.ChosenOptions);
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