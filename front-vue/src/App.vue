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
        {{Voting["questionInVoting"]}}
        <ul v-for="(option) in Voting.options" :key="option.index">
          <li>{{option}}</li>
        </ul>
      </div>
    </div>
    <hr />
    <button v-on:click="TestCreate">TEST</button>
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
      AllOptions: {},
      url: {
        users: "http://localhost:5001/user",
        votings: "http://localhost:5001/voting",
        options: "http://localhost:5001/options",
        usersAnswers: "http://localhost:5001/usersanswers"
      }
    };
  },
  mounted() {
    axios.get(this.url.options).then(response => {
			this.AllOptions = response.data[0];
		}).then(axios.get(this.url.votings)
      .then(response => {				
				this.AllVotings = response.data[0];
      }).then(this.AddOptionsInVotings()));  
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
    },
    TestCreate: function() {
      let indexOption = 0;
      let Votings = this.AllVotings;
      let OptionsInVoting = {};

      for (let Voting of Votings) {
        let votingID = Voting.votingID;
        OptionsInVoting[votingID] = Voting.votingID;
      }

      console.log(OptionsInVoting);
      // for (let indexOption = 0; i < Votings.length; indexOption++) {
      //   for (let Option of Options) {
      //     OptionsInVoting.indexOption = 1;
      //   }
      // }
    },
    AddOptionsInVotings: function() {
      let indexOption = 0;
      let indexVoting = 0;
      let Votings = this.AllVotings;
      let Options = this.AllOptions;

      let OptionsInVoting = {};

      // Votings[indexVoting].smt = smt; // получаем каждый объект и даём ему новое свойство
      //console.log(Option["votingID"]); // получаем каждый айди
      //console.log(Option); // получаем каждый Object

      for (let Voting in Votings) {
        for (let Option of Options) {
          if (Votings[indexVoting].votingID === Option["votingID"]) {
            Votings[indexVoting].options = Option;
            //delete Options[indexOption];
          }
          //indexOption++;
        }
        indexVoting++;
      }
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