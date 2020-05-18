<template>
  <div id="mainmenu">
    <button class="registerbtn" @click="Goto('active', 'ActiveVotings')">Active votings</button>
    <button class="registerbtn" @click="Goto('private', 'PrivateVotings')">Private votings</button>
    <button class="registerbtn" @click="Goto('deadline', 'DeadlineVotings')">Deadline votings</button>
    <button class="registerbtn" @click="Goto('uservotings', 'MyVotings')">My Votings</button>
    <router-link to="/signin">SignIn</router-link>
  </div>
</template>

<script>
export default {
  props: ["UserID"],
  data() {
    return {
      User: {
        UserID: null,
        TypeVoting: null
      },
      active: "active",
      privateVot: "private",
      deadline: "deadline",
      uservotings: "uservotings"
    };
  },
  methods: {
    Goto: function(TypeVoting, Path) {
      this.User.UserID = this.UserID;
      this.User.TypeVoting = TypeVoting;
      console.log(this.User);
      this.$router.push({ name: Path, params: this.User });
    }
  }
};
</script>