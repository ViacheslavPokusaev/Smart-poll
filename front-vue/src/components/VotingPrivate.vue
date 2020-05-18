<template>
  <div id="voting">
    <button @click="DeleteVoting">Удалить голосование</button>
    <input type="text" v-model="CurrentVoting.questionInVoting" />
    <hr />
    <div
      v-for="(properties) in CurrentVoting.options"
      :key="properties.index"
      :id="properties.optionID"
    >
      <input type="text" v-model="properties.nameOption" />
      <button :id="properties.optionID" @change="deleteOption">&#10008;</button>
    </div>
    <button :id="this.CurrentVoting.votingID" @click="addOption">+ вариант</button>
    Максимум голосов 1 юзером -
    <input type="text" id="checkMaxVotes" @blur="checkMaxVotes" />
    Конец голосования -
    <input type="text" v-model="NormalData" />
    <input type="checkbox" id="PubOrPri" v-model="PubOrPri" />
    <label for="PubOrPri">Оставить приватным? {{PubOrPri}}</label>
    <br />
    <button>Сохранить изменения</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentVoting", "User"],
  name: "Voting",
  data() {
    return {
			NewOption: null,
			PubOrPri: this.CurrentVoting.publicOrPrivate,
      NormalData: this.CurrentVoting.deadLine,
      RandomID: this.CurrentVoting.votingID,
      CountOpt: this.CurrentVoting.options.length
    };
  },
  computed: {},
  mounted: function() {},
  methods: {
    deleteOption: function(event) {
      console.log(event.target.id);
      let id = event.target.id;
      event.target.remove();
      let option = document.getElementById(id);
      option.remove();
      this.CountOpt--;
    },
    addOption: function() {
      let input = document.createElement("input");
      input.id = this.RandomID;
      input.type = "text";
      let button = document.createElement("button");
      button.id = this.RandomID;
      button.innerHTML = "&#10008;";
      let elem = document.getElementById(this.RandomID);
      elem.before(input);
      elem.before(button);
      button.onclick = this.deleteOption;
      this.CountOpt++;
    },
    checkMaxVotes: function() {
      let elem = document.getElementById("checkMaxVotes");
      console.log(elem.value);
      console.log(this.CurrentVoting.maxVotesByOneUser);
      if (Number(elem.value) > this.CountOpt) {
        elem.value = "";
        alert("Число раз должно быть меньше количества вариантов!");
      }
		},
		DeleteVoting: function(){
			axios.delete("http://localhost:5001/voting", { data: { VotingID: this.CurrentVoting.votingID } });
		}
  }
};
</script>

<style scoped>
button {
  background: aqua;
  border: 1px solid black;
  border-radius: 5px;
}

#STOP {
  background: red;
}
</style>