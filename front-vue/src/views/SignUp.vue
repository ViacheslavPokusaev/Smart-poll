<template>
  <div class="container">
    <h1>Register</h1>
    <p>Please fill in this form to create an account.</p>
    <hr />

    <label for="email">
      <b>Name</b>
    </label>
    <br />
    <input type="text" v-model.trim="addNewClient.FirstName" placeholder="Enter Name" name="email" />

    <br />
    <label for="age">
      <b>Age</b>
    </label>
    <br />
    <input
      type="text"
      @blur="checkAge"
      v-model.number="addNewClient.Age"
      placeholder="Enter Age"
      name="age"
    />

    <br />
    <label for="email">
      <b>Email</b>
    </label>
    <br />
    <input type="text" v-model.trim="addNewClient.Email" placeholder="Enter Email" name="email" />

    <br />
    <label for="psw">
      <b>Password</b>
    </label>
    <br />
    <input
      type="password"
      v-model.trim="addNewClient.Passw"
      placeholder="Enter Password"
      name="psw"
    />

    <hr />

    <button type="submit" class="registerbtn" @click="checkEdits">Sign Up</button>

    <div class="signin">
      <p>
        Already have an account?
        <router-link :to="{name: 'SignIn'}">Sign In</router-link>
      </p>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "SignUp",
  data() {
    return {
      addNewClient: {
        Id: 0,
        FirstName: "",
        Age: null,
        Email: "",
        Passw: ""
      }
    };
  },
  methods: {
    checkAge: function() {
      if (
        (this.addNewClient.Age < 18 || this.addNewClient.Age > 100) &&
        this.addNewClient.Age
      ) {
        alert("Вы дожны быть совершеннолетним!");
        this.addNewClient.Age = null;
      }
    },
    checkEdits: function() {
      if (
        !this.addNewClient.FirstName ||
        !this.addNewClient.Age ||
        !this.addNewClient.Email ||
        !this.addNewClient.Passw
      )
        alert("Не все поля заполненны, пожалуйста, заполните их!");
      else {
        axios
          .post("http://localhost:5001/client/signup", this.addNewClient)
          .then(response => {
            this.addNewClient.Id = response.data;
            this.$router.push({
              name: "Home",
              params: { Id: this.addNewClient.Id }
            });
          })
          .catch(error => {
            console.warn(error);
            this.addNewClient.FirstName = "";
            this.addNewClient.Age = null;
            this.addNewClient.Email = "";
            this.addNewClient.Passw = "";
            alert("Такой пользователь уже существует!");
          });
      }
    }
  }
};
</script>

<style scoped>
/* Add padding to containers */
.container {
  font-family: Arial, Helvetica, sans-serif;
  padding: 16px;
  background-color: white;
  border: 5px solid black;
}

/* Full-width input fields */
input[type="text"],
input[type="password"] {
  width: 97.5%;
  padding: 15px;
  margin: 5px 0 22px 0;
  display: inline-block;
  border: none;
  background: #f1f1f1;
}

input[type="text"]:focus,
input[type="password"]:focus {
  background-color: #ddd;
  outline: none;
}

/* Overwrite default styles of hr */
hr {
  border: 1px solid #f1f1f1;
  margin-bottom: 25px;
}

/* Set a style for the submit button */
.registerbtn {
  background-color: #4caf50;
  color: white;
  padding: 16px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}

.registerbtn:hover {
  opacity: 1;
}

/* Add a blue text color to links */
a {
  color: dodgerblue;
}

/* Set a grey background color and center the text of the "sign in" section */
.signin {
  background-color: #f1f1f1;
  text-align: center;
}
</style>