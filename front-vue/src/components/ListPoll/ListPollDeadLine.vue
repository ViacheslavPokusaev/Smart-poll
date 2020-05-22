<template>
  <div id="ListPollDeadLine">
    <a @click="Goto('Home')">Back into Menu</a>
    <br />
    <br />
    <div id="ListPollPublic">
      <div class="myclass" v-for="(Poll) in ListPollDead" :key="Poll.index">
        <PollDead :CurrentPoll="Poll" :Id="$route.params.Id" />
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import PollDead from "@/components/Poll/PollDead.vue";

export default {
  name: "ListPollDeadLine",
  data() {
    return {
      ListPollDead: {}
    };
  },
  mounted: function() {
    axios.get(this.$route.params.Url.ListPoll).then(response => {
      this.ListPollDead = response.data;
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
    PollDead
  }
};
</script>

<style scoped>
div {
  flex: 230px;
  margin: 5px 5px 5px 5px;
  /*background-color: white;*/
}

#ListPollDeadLine {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;

  padding: 5px 5px 5px 5px;
}

.myclass {
  border: 4px double black; /* Параметры границы */
  background: #fc3; /* Цвет фона */
  padding: 10px;

  flex-basis: 230px;

  min-height: 230px;
  max-width: 230px;
}
</style>