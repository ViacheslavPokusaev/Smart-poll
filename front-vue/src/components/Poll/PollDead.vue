<template>
  <div id="poll">
    <strong id="question">{{CurrentPoll.questionText}}</strong>
    <div v-for="(properties) in CurrentPoll.optionsPoll" :key="properties.index">
      <input type="checkbox" disabled/>
      <label>{{properties.textOption}} - 
				{{Math.floor((properties.countAnswer / CurrentPoll.countAllAnswer) * 100)}}%</label>
    </div>
    <strong>Автор - {{CurrentPoll.nameAuthorPoll}}</strong>
    <strong id="STOP">Это голосование оконченно!</strong>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentPoll", "Id"],
  name: "PollDead"
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

#STOP {
  margin-top: 10px;
  background: red;
}

strong {
  text-align: center;
}

#question {
  margin-bottom: 10px;
}
</style>