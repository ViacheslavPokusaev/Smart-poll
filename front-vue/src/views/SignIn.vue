<template>
  <div class="container">
    <h1>Sign In</h1>
    <p>Please fill in this form to sign in an account.</p>
    <hr />

    <label for="email">
      <b>Email</b>
    </label>
    <input type="text" v-model.trim="Email" placeholder="Enter Email" name="email" required />

    <label for="psw">
      <b>Password</b>
    </label>
    <input
      type="password"
      v-model.trim="UserPassword"
      placeholder="Enter Password"
      name="psw"
      required
    />

    <hr />

    <button type="submit" class="signinbth">SignIn</button>

    <div class="registration">
      <p>
        Don't have an account?
        <router-link to="/signup">Registration</router-link>
      </p>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      Email: "",
      UserPassword: ""
    };
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
.signinbth {
  background-color: #4caf50;
  color: white;
  padding: 16px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}

.signinbth:hover {
  opacity: 1;
}

/* Add a blue text color to links */
a {
  color: dodgerblue;
}

/* Set a grey background color and center the text of the "sign in" section */
.registration {
  background-color: #f1f1f1;
  text-align: center;
}
</style>