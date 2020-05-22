<template>
  <div id="ListPollPublic">
		<a @click="Goto('Home')">Back into Menu</a>
    <br />
    <br />
    <div class="myclass" v-for="(Poll) in ListPoll" :key="Poll.index">
      <PollPublic
        :CurrentPoll="Poll"
        :Id="$route.params.Id"
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
		ListPoll: function(){
			return this.ListPollPublic;
		}
	},
  created: function() {
    axios
      .get(this.$route.params.Url.ListPoll + `${this.$route.params.Id}`)
      .then(response => {
        this.ListPollPublic = response.data;
			});
	},
	methods:{
		Goto: function(Path) {
      this.$router.push({
        name: Path,
        params: { Id: this.$route.params.Id }
      });
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
  flex: 300px;
  margin: 5px 5px 5px 5px;
}

.myclass {
  margin: 5px 5px 5px 5px;
	display: flex;
  flex-direction: column;
  font: 16px "Oswald", sans-serif;
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;
  flex-basis: 270px;
  min-height: 300px;
  max-width: 270px;
}
</style>