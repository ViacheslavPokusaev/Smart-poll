<template>
  <div class="ListPollPublic">
    <div class="myclass" v-for="(Poll) in ListPollPublic" :key="Poll.index">
      <PollPublic
        :CurrentPoll="Poll"
        :Id="$route.params.Id"
        v-on:Add-Option="AddOption"
        v-on:Client-Answer="ClientAnswer"
      />
    </div>
  </div>
</template>

<script>
import axios from "axios";
import PollPublic from "@/components/Poll/PollPublic.vue";

export default {
  name: "ListPollPublic",
  data() {
    return {
      ListPollPublic: {}
    };
  },
  computed: {
		UpdateListPoll: function(id){
			axios
      .get(this.$route.params.Url.ListPoll + `${this.$route.params.Id}`)
      .then(response => {
        this.ListPollPublic = response.data;
      });
		}
	},
  mounted: function() {
    axios
      .get(this.$route.params.Url.ListPoll + `${this.$route.params.Id}`)
      .then(response => {
        this.ListPollPublic = response.data;
			});
			
		axios
      .post(this.$route.params.Url.GetIdOption, {
          PollId: 4,
          TextOption: "Начало"
        });
  },
  methods: {
    AddOption: function(TextOption, id) {
      console.log(this.$route.params.Url.AddOption);
      if (TextOption == "") alert("Вы не ввели текст нового варианта!");
      else {
        axios.post(this.$route.params.Url.AddOption, {
          PollId: id,
          TextOption: TextOption
        });
      }
    },
    ClientAnswer: function(ChosenOptions) {
      console.log(ChosenOptions);
      // if (ChosenOptions.length == 0)
      //   alert("Вы не выбрали ни одного варианта ответа!");
      // else {
      //   axios.post(this.$route.params.Url.AddAnswers, {
      //     Options: ChosenOptions,
      //     ClientId: this.$route.params.Id
      //   });
      // }
    }
  },
  components: {
    PollPublic
  }
};
</script>

<style scoped>
.ListPollPublic {
  box-sizing: border-box;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  flex: 270px;
  margin: 5px 5px 5px 5px;
}

.myclass {
  margin: 5px 5px 5px 5px;
  justify-content: flex-start;
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;
  flex-basis: 270px;
  min-height: 300px;
  max-width: 270px;
}
</style>