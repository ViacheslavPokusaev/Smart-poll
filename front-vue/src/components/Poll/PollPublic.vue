<template>
  <div id="poll">
    <strong id="question">{{CurrentPoll.questionText}}</strong>
    <div v-for="(properties, index) in CurrentPoll.optionsPoll" :key="index">
      <input
        type="checkbox"
        :id="index"
        v-on:change="CheckAnswers(index, $event)"
        v-bind:disabled="bool"
      />
      <label :for="properties.id">{{properties.textOption}}</label>
      <label
        v-if="bool"
      >- {{Math.floor((properties.countAnswer / CurrentPoll.countAllAnswer * 100), -2)}}%</label>
    </div>
    <input
      type="text"
      v-model="textOption"
      v-if="PossibleToAddOption()"
      placeholder="Enter text new option"
    />
    <button @click="AddOption" v-if="PossibleToAddOption()">+ Вариант</button>
    <button
      v-if="CurrentPoll.maxVotesByOneClient > 1 && !bool"
      v-bind:id="CurrentPoll.id"
      @click.once="Answer"
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
			smt: "smt",
      bool: false,
      textOption: "",
			ChosenOptions: [],
			ChosenOptionsId: []
    };
  },
  beforeDestroy() {
		console.log("Client Id - " + this.Id);
    for (let Id of this.ChosenOptionsId) {
			console.log("OptionId - " + this.CurrentPoll.optionsPoll[Id].id);		
			axios
          .post("http://localhost:5001/clientanswer", {
            OptionId: this.CurrentPoll.optionsPoll[Id].id,
            ClientId: this.Id
					})
					.catch(error => console.log(error));
		}
		console.log("---");
  },
  methods: {
    PossibleToAddOption: function() {
      let CurrentOptions = this.CurrentPoll.optionsPoll.length;
      if (this.CurrentPoll.isPossibleToAddOption) {
        if (++CurrentOptions > this.CurrentPoll.maxOptionsInPoll) return false;
        else return true;
      }
    },
    AddOption: function() {
      console.log(this.$route.params.Url.AddOption);
      if (this.textOption == "") alert("Вы не ввели текст нового варианта!");
      else {
        axios
          .post(this.$route.params.Url.AddOption, {
            PollId: this.CurrentPoll.id,
            TextOption: this.textOption
          })
          .then(response => {
            this.CurrentPoll.optionsPoll.push(response.data);
          });

        this.textOption = "";
      }
    },
    CheckAnswers: function(index, event) {
			console.log(this.$route.params.Url.AddAnswers);

      if (this.CurrentPoll.maxVotesByOneClient == 1) {

        ++this.CurrentPoll.optionsPoll[index].countAnswer;
				++this.CurrentPoll.countAllAnswer;
				this.ChosenOptionsId.push(index);
				this.bool = true;
				
      } else {
        if (event.target.checked === false) {
          this.ChosenOptions.splice(
            this.ChosenOptions.indexOf(event.target),
            1
					);
					
					this.ChosenOptionsId.splice(
            this.ChosenOptionsId.indexOf(index),
            1
					);

          --this.CurrentPoll.optionsPoll[index].countAnswer;
          --this.CurrentPoll.countAllAnswer;
        } else {
					this.ChosenOptions.push(event.target);
					this.ChosenOptionsId.push(index);

          ++this.CurrentPoll.optionsPoll[index].countAnswer;
          ++this.CurrentPoll.countAllAnswer;

          if (
            this.ChosenOptions.length > this.CurrentPoll.maxVotesByOneClient
          ) {
            this.ChosenOptions.pop().checked = false;
						this.ChosenOptions.pop().checked = false;
						this.ChosenOptionsId.pop();
						this.ChosenOptionsId.pop();

            event.target.checked = true;
						this.ChosenOptions.push(event.target);
						this.ChosenOptionsId.push(index);

            ++this.CurrentPoll.optionsPoll[index].countAnswer;
            ++this.CurrentPoll.countAllAnswer;
          }
        }
      }
    },
    Answer: function() {
      this.bool = true;
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