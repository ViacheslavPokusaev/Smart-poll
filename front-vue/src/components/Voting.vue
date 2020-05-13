<template>
  <div id="voting">
    {{CurrentVoting.questionInVoting}}
    <div v-for="(properties) in CurrentVoting.options" :key="properties.index">
      <input
        type="checkbox"
        v-bind:id="properties.optionID + `;` + CurrentVoting.maxVotesByOneUser"
        v-on:change="checkVoting"
      />
      <label>{{properties.nameOption}}</label>
    </div>
    <button v-bind:id="CurrentVoting.votingID + `id`">Добавить свой вариант</button>
    <button v-bind:id="CurrentVoting.votingID">Проголосовать</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentVoting"],
  name: "listvotings",
  data() {
    return {
      addNewOptions: null,
      AllUserAnswers: 0,
      selectedOptins: [],
      addUser: {},
      AllVotings: {},
      url: {
        users: "http://localhost:5001/user",
        votings: "http://localhost:5001/voting",
        usersAnswers: "http://localhost:5001/usersanswers"
      }
    };
  },
  methods: {
    checkVoting: function(event) {
      //alert(event.target.id); // ай ди
      //alert( event.target.id.indexOf(';') );

      let maxVotesByOneUser = event.target.id.substring(
        event.target.id.indexOf(";") + 1
      );
      let OptionID = event.target.id.substring(0, event.target.id.indexOf(";"));
      console.log(
        "maxVotesByOneUser - " +
          maxVotesByOneUser +
          " " +
          "OptionID - " +
          OptionID
      );

      this.AllUserAnswers++;
      console.log(this.AllUserAnswers);
      if (this.AllUserAnswers > maxVotesByOneUser) {
        alert("ErroR!!");
        event.target.checked = false;
      }
    }
  }
};
</script>

<style scoped>
</style>