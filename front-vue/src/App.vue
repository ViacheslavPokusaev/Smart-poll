<template>
  <div id="app">
    <!--<GetData v-bind:info="items"/>-->
    <input type="text" id="myid" />
    <button v-on:click="greet">OK</button>
    <button v-on:click="GetData">GET</button>
    <br />
    <br />
    <div id="form">
      <input type="text" id="Email" placeholder="Enter your email" />
      <input type="text" id="UserPassword" placeholder="Enter your password" />
      <input type="text" id="UserName" placeholder="Enter your name" />
      <input type="text" id="Age" placeholder="Enter your age" />
      <button v-on:click="sendData">PUSH</button>
    </div>
    <hr />
    <hr />
    <div id="votings">
      <button @click="GetAllVotings">GetAllVotings</button>
      <div class="myclass" v-for="item in AllVotings" :key="item.index">{{item["questionInVoting"]}}</div>
      <hr />
      <button v-on:click="AddObject">ADD</button>
    </div>

    <!--<Test/>-->
    <router-view />
  </div>
</template>

<script>
import axios from "axios";
//import GetData from '@/components/GetData';

export default {
  name: "app",
  data() {
    return {
      addUser: {},
      users: null,
      name: "dsdsdsd",
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
    axios.get("http://localhost:5001/voting").then(response => {
      this.AllVotings = response.data[0];
      //console.log(this.AllVotings);
		});
		axios.get("http://localhost:5001/options").then(response => {
      this.AllOptions = response.data[0];
      console.log(this.AllOptions);
    });
  },
  methods: {
    greet: async function() {
      let idVoting = document.getElementById("myid").value;
      let response = await fetch(this.url.users + `/${idVoting}`);
      if (response.ok) this.users = await response.json();
    },
    sendData: function() {
      //let NewUser = {};
      let form = document.getElementById("form");
      for (let elem of form.children) {
        this.addUser[elem.id] = elem.value;
      }
      this.addUser["Age"] = Number(this.addUser["Age"]);
      console.log(this.addUser);

      let response = fetch(this.url.users, {
        method: "POST", // или 'PUT'
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.addUser) // данные могут быть 'строкой' или {объектом}!
      });
      console.log(this.addUser);
      console.log(JSON.stringify(this.addUser));
      const json = response;
      console.log("Успех:", json.server);
    },
    GetData: function() {
      console.log(this.users[0]);
      //for (let key in this.users) console.log(this.users[key]);
    },
    GetAllVotings: function() {
      axios.get(this.url.votings).then(response => {
        this.AllVotings = response.data[0];
        console.log(this.AllVotings);
      });
      // console.log(this.AllVotings);
      // this.AllVotings[0].votingID = 1000;
      //let url = "http://localhost:5001/voting";
      //fetch(url).then(response => response.json()).then(json => this.AllVotings = json[0]);
      // this.AllVotings = response.json();
      //console.log(this.AllVotings);
    },
    AddObject: function() {
      let index = 0;
      let smt = { name: "test", age: 18 };
      for (let Voting in this.AllVotings) {
        this.AllVotings[index].smt = smt;
        console.log(this.AllVotings[index]);
        index++;
      }
    }
  },
  components: {
    //GetData
  }
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