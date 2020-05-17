<template>
  <div id="listvotings">
    <div class="myclass" v-for="(Voting) in Votings" :key="Voting.index">
      <OneVoting v-bind:CurrentVoting="Voting" />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import OneVoting from "@/components/Voting.vue";

export default {
  props: ["Filter"],
  name: "listvotings",
  data() {
    return {
      Votings: {},
      url: {
        active: "http://localhost:5001/voting/common/public",
        private: "http://localhost:5001/voting/privatevotings/", // need UserID
        deadline: "http://localhost:5001/voting/common/deadline",
        uservotings: "http://localhost:5001/voting/uservotings/" // need UserID
      }
    };
  },
  mounted() {
    if (this.Filter === "active") {
      axios.get(this.url.active).then(response => {
        this.Votings = response.data[0];
      });
    }
  },
  components: {
    OneVoting
  }
};
</script>

<style scoped>
div {
  flex: 200px;
  margin: 5px 5px 5px 5px;
  /*background-color: white;*/
}


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

  min-height: 250px;
  max-width: 250px;
}
</style>