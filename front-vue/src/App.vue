<template>
  <div id="app">
    <div id="form">
      <input type="text" id="Email" placeholder="Enter your email" />
      <input type="text" id="UserPassword" placeholder="Enter your password" />
      <input type="text" id="UserName" placeholder="Enter your name" />
      <input type="text" id="Age" placeholder="Enter your age" />
      <button v-on:click="sendData">PUSH</button>
    </div>
    <hr />
    <div id="votings">
      <div class="myclass" v-for="(Voting) in AllVotings" :key="Voting.index">
        {{Voting.questionInVoting}}
        <div v-for="(properties) in Voting.options" :key="properties.index">
          <div v-for="(option) in properties.nameOption" :key="option.index">{{option}}</div>
        </div>
      </div>
    </div>
    <hr />
    <router-view />
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "app",
  data() {
    return {
      addUser: {},
      AllVotings: {},
      url: {
        users: "http://localhost:5001/user",
        votings: "http://localhost:5001/voting",
        usersAnswers: "http://localhost:5001/usersanswers"
      }
    };
  },
  mounted() {
    axios.get(this.url.votings).then(response => {
      this.AllVotings = response.data[0];
    });
  },
  methods: {
    sendData: function() {
      let form = document.getElementById("form");
      for (let elem of form.children) {
        this.addUser[elem.id] = elem.value;
      }
      this.addUser["Age"] = Number(this.addUser["Age"]);

      let response = fetch(this.url.users, {
        method: "POST", // или 'PUT'
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.addUser) // данные могут быть 'строкой' или {объектом}!
      });
    }
  },
  components: {}
};
</script>

<style scoped>
@import "components/reboot.css";
#app {
  /*display: flex;
		flex-wrap: wrap;
		justify-content: space-around;
		*/
  background-color: aqua;
}
div {
  flex: 200px;
  margin: 5px 5px 5px 5px;
  background-color: red;
}

.myclass {
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;
}
</style>