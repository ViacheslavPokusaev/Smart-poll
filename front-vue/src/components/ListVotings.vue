<template>
  <div id="listvotings">
    <div class="myclass" v-for="(Voting) in AllVotings" :key="Voting.index">
      {{Voting.questionInVoting}}
      <div v-for="(properties) in Voting.options" :key="properties.index">
        <input
          type="checkbox"
          v-bind:id="properties.optionID + `;` + Voting.maxVotesByOneUser"
          v-on:change="checkVoting"
        />
        <label>{{properties.nameOption}}</label>
      </div>
      <button v-bind:id="Voting.votingID + `id`">Добавить свой вариант</button>
      <button v-bind:id="Voting.votingID">Проголосовать</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import Voting from "@/components/Voting";

export default {
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
  created() {
    axios.get(this.url.votings).then(response => {
      this.AllVotings = response.data[0];
    });
  },
  components: {
    Voting
  }
};
</script>

<style scoped>
</style>