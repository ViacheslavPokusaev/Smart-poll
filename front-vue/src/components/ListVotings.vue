<template>
  <div id="listvotings">
    <div class="myclass" v-for="(Voting) in AllVotings" :key="Voting.index">
      <OneVoting v-bind:CurrentVoting="Voting"/>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import OneVoting from "@/components/Voting.vue";

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
    OneVoting
  }
};
</script>

<style scoped>
</style>