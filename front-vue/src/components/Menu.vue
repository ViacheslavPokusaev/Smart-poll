<template>
  <div id="mainmenu">
    <button class="registerbtn" @click="Goto('active', 'ActiveVotings')">Active votings</button>
    <button class="registerbtn" @click="Goto('private', 'PrivateVotings')">Private votings</button>
    <button class="registerbtn" @click="Goto('deadline', 'DeadlineVotings')">Deadline votings</button>
    <button class="registerbtn" @click="Goto('uservotings', 'MyVotings')">My Votings</button>
    <!-- <button type="submit" class="registerbtn" @click="Goto('active', 'ActiveVotings')">Active votings</button>
    <button type="submit" class="registerbtn" @click="Goto('private', 'PrivateVotings')">Private votings</button>
    <button type="submit" class="registerbtn" @click="Goto('deadline', 'DeadlineVotings')">Deadline votings</button>
    <button type="submit" class="registerbtn" @click="Goto('uservotings', 'MyVotings')">My Votings</button>-->
    <!-- <router-link :to="{name: 'ActiveVotings', params: User}">Active votings</router-link> -->
    <!-- <router-link :to="{name: 'PrivateVotings', params: {UserID, privateVot}}">Private votings</router-link>
    <router-link :to="{name: 'DeadlineVotings', params: deadline}">Deadline votings</router-link>
    <router-link :to="{name: 'MyVotings', params: {UserID, uservotings}}">My Votings</router-link>-->
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