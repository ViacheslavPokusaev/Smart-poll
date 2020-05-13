<template>
  <div id="app">
    <ListVotings />
    <div id="form">
      <input type="text" id="Email" placeholder="Enter your email" />
      <input type="text" id="UserPassword" placeholder="Enter your password" />
      <input type="text" id="UserName" placeholder="Enter your name" />
      <input type="text" id="Age" placeholder="Enter your age" />
      <button v-on:click="sendData">PUSH</button>
    </div>
    <hr />
    <router-view />
  </div>
</template>

<script>
import axios from "axios";
import ListVotings from "@/components/ListVotings.vue";

export default {
  name: "app",
  data() {
    return {
      addNewOptions: null
      // AllUserAnswers: 0,
      // selectedOptins: [],
      // addUser: {},
      // AllVotings: {},
      // url: {
      //   users: "http://localhost:5001/user",
      //   votings: "http://localhost:5001/voting",
      //   usersAnswers: "http://localhost:5001/usersanswers"
      // }
    };
  },
  // created() {
  //   axios.get(this.url.votings).then(response => {
  //     this.AllVotings = response.data[0];
  //   });
  // },
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
  components: {
    ListVotings
  }
};
</script>

<style>
@import "assets/reboot.css";
/*#app {
  display: flex;
		flex-wrap: wrap;
		justify-content: space-around;
		
  background-color: aqua;

}*/
div {
  flex: 200px;
  margin: 5px 5px 5px 5px;
  /*background-color: white;*/
}

.myclass {
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;
}

button {
  background: aqua;
  border: 1px solid black;
  border-radius: 5px;
}
</style>