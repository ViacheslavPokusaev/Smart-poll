<template>
  <div id="voting">
    <button @click="$emit('Delete-Voting', CurrentVoting.votingID, 'private')">Удалить голосование</button>
    <input type="text" v-model="CurrentVoting.questionInVoting" />
    <hr />
    <div
      v-for="(properties) in CurrentVoting.options"
      :key="properties.index"
      :id="properties.optionID"
    >
      <input type="text" v-model="properties.nameOption" v-bind:unique="CurrentVoting.votingID" />
      <button :id="properties.optionID" @click="deleteOption">&#10008;</button>
    </div>
    <button :id="CurrentVoting.votingID" @click="addOption">+ вариант</button>
    <br />Максимум вариантов -
    <input type="text" v-model.number="CurrentVoting.maxOptions" />
    Максимум голосов 1 юзером -
    <input
      type="text"
      @blur="checkMaxVotes"
      v-model.number="CurrentVoting.maxVotesByOneUser"
    />
    Конец голосования -
    <input type="text" v-model="NormalData" />
    <input type="checkbox" id="AddOptions" v-model="CurrentVoting.addNewOptions" />
    <label for="AddOptions">Разрешить добавление вариантов?</label>
    <br />
    <input type="checkbox" id="PubOrPri" v-model="CurrentVoting.publicOrPrivate" />
    <label for="PubOrPri">Оставить приватным?</label>
    <br />
    <button @click="$emit('Update-Voting', Publish(), CountOpt, 'private')">Сохранить изменения</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  props: ["CurrentVoting", "User"],
  name: "Voting",
  data() {
    return {
      NewVoting: {},
      NewOption: null,
      NormalData: this.CurrentVoting.deadLine,
      RandomID: this.CurrentVoting.votingID,
      CountOpt: this.CurrentVoting.options.length
    };
  },
  computed: {},
  mounted: function() {},
  methods: {
    deleteOption: function(event) {
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
      input.setAttribute("unique" + this.RandomID, this.RandomID);
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
      if (
        this.CurrentVoting.maxVotesByOneUser > this.CountOpt &&
        this.CountOpt != 0
      ) {
        this.CurrentVoting.maxVotesByOneUser = null;
        alert("Число раз должно быть меньше количества вариантов!");
      }
    },
    Publish: function() {
      let inputs = document.querySelectorAll("[unique" + this.RandomID + "]");

      this.NewVoting["Options"] = [];
      for (let elem of inputs) {
        if (elem.value != "") this.NewVoting["Options"].push(elem.value);
			}
			
      if (this.CountOpt != 0 && this.NewVoting["Options"].length != 0) {
        this.NewVoting["VotingID"] = this.CurrentVoting.votingID;
        this.NewVoting["AddNewOptions"] = this.CurrentVoting.addNewOptions;
        this.NewVoting["MaxOptions"] = this.CurrentVoting.maxOptions;
        this.NewVoting[
          "MaxVotesByOneUser"
        ] = this.CurrentVoting.maxVotesByOneUser;
        this.NewVoting[
          "QuestionInVoting"
        ] = this.CurrentVoting.questionInVoting;
        this.NewVoting["DeadLine"] = this.NormalData;
        this.NewVoting["PublicOrPrivate"] = this.CurrentVoting.publicOrPrivate;
        return this.NewVoting;
      } else return "";
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