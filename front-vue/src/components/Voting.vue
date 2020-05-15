<template>
  <div id="voting">
    <strong>{{CurrentVoting.questionInVoting}}</strong>
    <div v-for="(properties) in CurrentVoting.options" :key="properties.index">
      <input type="checkbox" v-bind:id="properties.optionID" v-on:change="checkVoting" />
      <label>{{properties.nameOption}}</label>
    </div>
    <button v-if="CurrentVoting.addNewOptions" v-bind:id="CurrentVoting.votingID + `id`">+ вариант</button>
    <button v-bind:id="CurrentVoting.votingID">Проголосовать</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentVoting"],
  name: "listvotings",
  data() {
    return {
      AllUserAnswers: 0,
      ChosenOptions: []
    };
  },
  methods: {
    checkVoting: function(event) {
			let Option = event.target;

      if (this.CurrentVoting.maxVotesByOneUser == 1) {
        this.ChosenOptions.unshift(Option.id);
        if (this.ChosenOptions.length > 1)
          document.getElementById(this.ChosenOptions.pop()).checked = false;
      } else {
        if (Option.checked === false) {
          this.ChosenOptions.splice(
            this.ChosenOptions.indexOf(Option.id) - 1,
            1
          );
        } else {
          this.ChosenOptions.push(Option.id);
          if (
            this.ChosenOptions.length > this.CurrentVoting.maxVotesByOneUser
          ) {
            Option.checked = true;
						this.ChosenOptions.pop();
						document.getElementById(this.ChosenOptions.pop()).checked = false;
						this.ChosenOptions.push(Option.id);
            console.log(this.ChosenOptions);
          }
        }
      }
    }
  }
};
</script>

<style scoped>
</style>