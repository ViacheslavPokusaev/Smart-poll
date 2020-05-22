<template>
  <div id="poll">
    <strong id="question">{{CurrentPoll.questionText}}</strong>
    <div v-for="(properties, index) in CurrentPoll.optionsPoll" :key="index">
      <input type="checkbox" disabled />
      <label :for="properties.id">{{properties.textOption}}</label>
      <label>- {{Math.floor((properties.countAnswer / CurrentPoll.countAllAnswer * 100), -2)}}%</label>
    </div>
    <button :id="index" @click.once="Delete">Удалить голосование</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentPoll", "Id", "index"],
  name: "PollPublish",
  methods: {
    Delete: function() {
      axios
        .post(
          this.$route.params.Url.Delete +
            `${this.CurrentPoll.id}`)
        .catch(error => console.log(error));
      this.CurrentPoll.optionsPoll.splice(event.target.id, 1);
    }
  }
};
</script>

<style scoped>
#poll {
  display: flex;
  flex-direction: column;
  font: 16px "Oswald", sans-serif;
}

button {
  font: 16px "Oswald", sans-serif;
  background: aqua;
  border: 1px solid black;
  border-radius: 5px;
  margin-top: 10px;
}

#Author {
  margin-top: 10px;
  margin-bottom: 10px;
}

#NameAuthor {
  color: red;
  font-weight: 600;
}

strong {
  text-align: center;
}

#question {
  margin-bottom: 10px;
}

input[type="text"] {
  margin-top: 5px;
}
</style>