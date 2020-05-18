<template>
  <div class="container">
    <h1>Register</h1>
    <p>Please fill in this form to create an account.</p>
    <hr />

    <label for="email">
      <b>Name</b>
    </label>
    <input type="text" v-model.trim="addNewUser.UserName" placeholder="Enter Name" name="email" />

    <label for="age">
      <b>Age</b>
    </label>
    <input
      type="text"
      @blur="checkAge"
      v-model.number="addNewUser.Age"
      placeholder="Enter Age"
      name="age"
    />
    <label for="email">
      <b>Email</b>
    </label>
    <input type="text" v-model.trim="addNewUser.Email" placeholder="Enter Email" name="email" />

    <label for="psw">
      <b>Password</b>
    </label>
    <input
      type="password"
      v-model.trim="addNewUser.UserPassword"
      placeholder="Enter Password"
      name="psw"
    />

    <hr />

    <button type="submit" class="registerbtn" @click="checkEdits">Registration</button>

    <div class="signin">
      <p>
        Already have an account?
        <router-link :to="{name: 'SignIn', params: User}">Sign In</router-link>
      </p>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Registration",
  data() {
    return {
      addNewUser: {
        UserName: "",
        Age: null,
        Email: "",
        UserPassword: ""
      },
      User: {
        UserID: null
      },
      userPost: "http://localhost:5001/user/singup"
    };
  },
  methods: {
    checkAge: function() {
      if (
        (this.addNewUser.Age < 18 || this.addNewUser.Age > 100) &&
        this.addNewUser.Age
      ) {
        alert("Вы дожны быть совершеннолетним!");
        this.addNewUser.Age = null;
      }
    },
    checkEdits: function() {
      if (
        !this.addNewUser.UserName ||
        !this.addNewUser.Age ||
        !this.addNewUser.Email ||
        !this.addNewUser.UserPassword
      )
        alert("Не все поля заполненны, пожалуйста, заполните их!");
      else {
        axios
          .post(this.userPost, this.addNewUser)
          .then(response => {
            this.User.UserID = response.data;
            this.$router.push({ name: "Home", params: this.User });
          })
          .catch(error => {
            console.log(error);
            this.addNewUser.UserName = "";
            this.addNewUser.Age = null;
            this.addNewUser.Email = "";
            this.addNewUser.UserPassword = "";
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
  width: 100%;
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