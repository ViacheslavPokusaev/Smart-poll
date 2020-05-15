<template>
  <div id="listvotings">
    <div class="myclass" v-for="(Voting) in AllVotings" :key="Voting.index">
      <OneVoting v-bind:CurrentVoting="Voting" />
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
      AllVotings: {},
      url: {
        votings: "http://localhost:5001/voting"
      }
    };
  },
  mounted() {
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
#listvotings {
  display: flex;
  flex-wrap: wrap;
	/* justify-content: center; */

  padding: 5px 5px 5px 5px;
}

.myclass {
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;
  
	flex-basis: 250px;

  height: 250px;
  max-width: 250px;
}
</style>