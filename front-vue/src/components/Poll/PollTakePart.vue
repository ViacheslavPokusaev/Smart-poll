<template>
  <div id="poll">
    <strong id="question">{{CurrentPoll.questionText}}</strong>
    <div v-for="(properties) in CurrentPoll.optionsPoll" :key="properties.index">
      <input type="checkbox" disabled/>
      <label>{{properties.textOption}} - 
				{{Math.floor((properties.countAnswer / CurrentPoll.countAllAnswer * 100), -2)}}%</label>
    </div>
    <strong id="Author">Автор - <strong id="NameAuthor">{{CurrentPoll.nameAuthorPoll}}</strong></strong>
    <TimerPoll :DeadLine="CurrentPoll.deadLine"/>
  </div>
</template>

<script>
import axios from "axios";
import TimerPoll from "@/components/TimerPoll.vue";

export default {
  props: ["CurrentPoll", "Id"],
  name: "PollTakePart",
	components: {
		TimerPoll
	}
};
</script>

<style scoped>
#poll {
  display: flex;
  flex-direction: column;
}

button {
  background: aqua;
  border: 1px solid black;
  border-radius: 5px;
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