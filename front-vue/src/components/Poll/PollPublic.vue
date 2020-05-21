<template>
  <div id="poll">
    <strong id="question">{{CurrentPoll.questionText}}</strong>
    <div v-for="(properties) in CurrentPoll.optionsPoll" :key="properties.index">
      <input type="checkbox" :id="properties.id" v-on:change="CheckAnswers" />
      <label :for="properties.id">{{properties.textOption}}</label>
    </div>
    <input
      type="text"
      v-model="TextOption"
      v-if="PossibleToAddOption()"
      placeholder="Enter text new option"
    />
    <button
      @click="$emit('Add-Option', AddOption(), CurrentPoll.id)"
      v-if="CurrentPoll.isPossibleToAddOption"
      v-bind:id="CurrentPoll.id"
    >+ Вариант</button>
    <button
      v-if="CurrentPoll.maxVotesByOneClient > 1"
      v-bind:id="CurrentPoll.id"
      @click="$emit('Client-Answer', ChosenOptions)"
    >Голосовать</button>

    <strong id="Author">
      Автор -
      <strong id="NameAuthor">{{CurrentPoll.nameAuthorPoll}}</strong>
    </strong>
    <TimerPoll :DeadLine="CurrentPoll.deadLine" />
  </div>
</template>

<script>
import axios from "axios";
import TimerPoll from "@/components/TimerPoll.vue";

export default {
  props: ["CurrentPoll", "Id"],
  name: "PollPublic",
  data() {
    return {
      TextOption: "",
      ChosenOptions: []
    };
  },
  computed: {},
  methods: {
    PossibleToAddOption: function() {
      let CurrentOptions = this.CurrentPoll.optionsPoll.length;
      if (this.CurrentPoll.isPossibleToAddOption) {
        if (++CurrentOptions > this.CurrentPoll.maxOptionsInPoll) return false;
        else return true;
      }
    },
    AddOption: function() {
      let option = this.TextOption;
      this.TextOption = "";
      return option;
    },
    CheckAnswers: function(event) {
      if (event.target.checked === false) {
        this.ChosenOptions.splice(this.ChosenOptions.indexOf(event.target.id));
      } else {
        this.ChosenOptions.push(event.target.id);
        if (this.ChosenOptions.length > this.CurrentPoll.maxOptionsInPoll) {
          event.target.checked = true;
          this.ChosenOptions.pop();
					document.getElementById(this.ChosenOptions.pop()).checked = false;
					let NumberId = Number(event.target.id);
          this.ChosenOptions.push(NumberId);
        }
      }
    }
  },
  components: {
    TimerPoll
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
  background: red;
}

strong {
  text-align: center;
}

#question {
  margin-bottom: 10px;
}
</style>