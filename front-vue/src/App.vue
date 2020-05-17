<template>
  <div id="app">
    <router-view />
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "app",
  data() {
    return {};
  },
  methods: {},
  components: {}
};
</script>

<style scoped>
@import "assets/reboot.css";

#app {
  display: flex;
  flex-direction: column;
  justify-content: center;
}

div {
  flex: 200px;
  margin: 5px 5px 5px 5px;
  /*background-color: white;*/
}

button {
  background: aqua;
  border: 1px solid black;
  border-radius: 5px;
}
</style>