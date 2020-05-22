<template>
  <div class="ListPollPublish">
    <a @click="Goto('Home')">Back into Menu</a>
    <div class="myclass" v-for="(Poll, index) in ListPollPublish" :key="index">
      <PollPublish :CurrentPoll="Poll" :Id="$route.params.Id" :index="index"/>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import PollPublish from "@/components/Poll/PollPublish.vue";

export default {
  name: "ListPollPublish",
  data() {
    return {
      ListPollPublish: {}
    };
  },
  created: function() {
    axios
      .get(this.$route.params.Url.ListPoll + `${this.$route.params.Id}`)
      .then(response => {
        this.ListPollPublish = response.data;
      });
  },
  methods: {
    Goto: function(Path) {
      this.$router.push({
        name: Path,
        params: { Id: this.$route.params.Id }
      });
    }
  },
  components: {
    PollPublish
  }
};
</script>

<style scoped>
.ListPollPublish {
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
  font: 16px "Oswald", sans-serif;
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;
  flex-basis: 225px;
  min-height: 230px;
  max-width: 270px;
}
</style>