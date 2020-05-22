<template>
  <div class="ListPollPrivate">
    <a @click="Goto('Home')">Back into Menu</a>
    <br />
    <br />
    <div v-for="(Poll, index) in ListPollPrivate" :key="index">
      <PollPrivate
        :CurrentPoll="Poll"
        :Id="$route.params.Id"
        :index="index"
        v-on:Save-Changes="SaveChanges"
        v-on:Delete-Poll="DeletePoll"
      />
    </div>
    <button @click="CreateNewPoll">Создать голосование</button>
  </div>
</template>

<script>
import axios from "axios";
import PollPrivate from "@/components/Poll/PollPrivate.vue";

export default {
  name: "ListPollPrivate",
  data() {
    return {
      ListPollPrivate: {},
      DefaultPoll: {
        QuestionText: "Ваш ответ",
        DeadLine: "2020-05-28",
        IsPrivate: true,
        MaxVotesByOneClient: 1,
        MaxOptionsInPoll: 19,
        IsPossibleToAddOption: false,
        ClientId: this.$route.params.Id
      }
    };
  },
  created: function() {
    axios
      .get(this.$route.params.Url.ListPoll + `${this.$route.params.Id}`)
      .then(response => {
        this.ListPollPrivate = response.data;
      });
  },
  methods: {
    Goto: function(Path) {
      this.$router.push({
        name: Path,
        params: { Id: this.$route.params.Id }
      });
    },
    SaveChanges: function(deleteFromList, index) {
      if (deleteFromList === false) {
        this.ListPollPrivate.splice(index, 1);
      }
    },
    DeletePoll: function(id, index) {
      console.log(id);
      this.ListPollPrivate.splice(index, 1);
      axios.post(this.$route.params.Url.Delete + `${id}`);
    },
    CreateNewPoll: function() {
      axios
        .post(this.$route.params.Url.Create, this.DefaultPoll)
        .then(response => this.ListPollPrivate.push(response.data))
    }
  },
  components: {
    PollPrivate
  }
};
</script>

<style scoped>
.ListPollPrivate {
  display: flex;
  margin: 5px 5px 5px 5px;
}
</style>