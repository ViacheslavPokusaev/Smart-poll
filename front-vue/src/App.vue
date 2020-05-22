<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script>
export default {
  name: "app"
};
</script>

<style>
body {
  font-family: "Oswald", sans-serif;
  background: #212;
}

nav {
	text-align: center;
	font-size: 25pt;
	margin-left: auto;
  margin-right: auto;
	width: 100%;
	height: 100%;
}

input[type="text"], input[type="password"]{
	font: 16px "Oswald", sans-serif;
}

a {
  text-decoration: none;
  color: #fff;
  width: 200px;
  display: inline-block;
  text-align: center;
  transition: all 0.33s linear;
}
</style>