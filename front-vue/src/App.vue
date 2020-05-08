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
    </div>
    <button v-on:click="sendData">PUSH</button>
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
      url: "http://localhost:5001/user",
      addUser: {},
      users: null,
      name: "dsdsdsd"
    };
  },
  methods: {
    greet: async function() {
      let idVoting = document.getElementById("myid").value;
      let url = "http://localhost:5001/voting/user" + `/${idVoting}`;
      console.log(url);
      let response = await fetch(url);
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

      let response = fetch(this.url, {
				method: "POST", // или 'PUT'
				headers: {
					"Content-Type": "application/json"
        },
        body: JSON.stringify(this.addUser), // данные могут быть 'строкой' или {объектом}!    
      });
      console.log(this.addUser);
			console.log(JSON.stringify(this.addUser));
      const json = response;
      console.log("Успех:", json.server);
    },
    GetData: function() {
      console.log(this.users[0]);
      //for (let key in this.users) console.log(this.users[key]);
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
</style>