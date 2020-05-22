<template>
  <nav>
    <a @click="Goto('ListPollTakePart')">MyPoll</a>
    <a @click="Goto('ListPollDeadLine')">Deadline</a>
    <a @click="Goto('ListPollPrivate')">Private</a>
    <a @click="Goto('ListPollPublic')">Public</a>
    <a @click="Goto('ListPollPublish')">Publish</a>
    <a @click="Goto('SignIn')">Sign In</a>
    <div id="smt"></div>
  </nav>
</template>

<script>
export default {
  props: ["Id"],
  data() {
    return {
      url: {
        ListPollPublic: {
					ListPoll: "http://localhost:5001/poll/common/public/",
					AddOption: "http://localhost:5001/poll/addoption"
				},
        ListPollPrivate: {
					ListPoll: "http://localhost:5001/poll/private/",
					AddOption: "http://localhost:5001/poll/addoption",
					DeleteOption: "http://localhost:5001/poll/deleteoption/",
					Update: "http://localhost:5001/poll/update",
					Delete: "http://localhost:5001/poll/delete/",
					Create: "http://localhost:5001/poll"
				},
        ListPollDeadLine: {
					ListPoll: "http://localhost:5001/poll/common/deadline"
				},
        ListPollTakePart: {
					ListPoll: "http://localhost:5001/poll/takepart/"
				},
				ListPollPublish:{
					ListPoll: "http://localhost:5001/poll/client/",
					Delete: "http://localhost:5001/poll/deleteall/"
				}
      }
    };
  },
  methods: {
    Goto: function(Path) {
      let CurrentUrl;
      if (Path == "ListPollTakePart") CurrentUrl = this.url.ListPollTakePart;
      else if (Path == "ListPollDeadLine") CurrentUrl = this.url.ListPollDeadLine;
      else if (Path == "ListPollPublic") CurrentUrl = this.url.ListPollPublic;
			else if(Path == "ListPollPrivate") CurrentUrl = this.url.ListPollPrivate;
			else if(Path == "ListPollPublish") CurrentUrl = this.url.ListPollPublish;

      this.$router.push({ name: Path, params: { Url: CurrentUrl, Id: this.Id } });
    }
  }
};
</script>

<style scoped>
#smt {
  margin-left: 7.5%;
  width: 10%;
  height: 2px;
  background: #fff;
}

a {
  text-decoration: none;
  color: #fff;
  width: 200px;
  display: inline-block;
  text-align: center;
  transition: all 0.33s linear;
}

a:nth-child(1) ~ div {
  transition: all 0.33s linear;
  -webkit-transition: all 0.33s linear;
}

a:nth-child(2):hover ~ div {
  transform: translate(152%);
  background-color: #e74c3c;
  transition: all 0.33s linear;
  -webkit-transition: all 0.33s linear;
}

/*translate(240px);*/

a:nth-child(3):hover ~ div {
  transform: translate(299%);
  background-color: #bf55ec;
  transition: all 0.33s linear;
  -webkit-transition: all 0.33s linear;
}

a:nth-child(4):hover ~ div {
  transform: translate(447%);
  background-color: #f39c12;
  color: #03c9a9;
  transition: all 0.33s linear;
  -webkit-transition: all 0.33s linear;
}

a:nth-child(5):hover ~ div {
  transform: translate(595%);
  background-color: aqua;
  color: #03c9a9;
  transition: all 0.33s linear;
  -webkit-transition: all 0.33s linear;
}

a:nth-child(6):hover ~ div {
  transform: translate(744%);
  background-color: #f39c12;
  color: #03c9a9;
  transition: all 0.33s linear;
  -webkit-transition: all 0.33s linear;
}

a:nth-child(1):hover {
  color: #87eba5;
}

a:nth-child(2):hover {
  color: #e74c3c;
}

a:nth-child(3):hover {
  color: #bf55ec;
}

a:nth-child(4):hover {
  color: #f39c12;
}

a:nth-child(5):hover {
  color: aqua;
}

a:nth-child(6):hover {
  color: red;
}
</style>