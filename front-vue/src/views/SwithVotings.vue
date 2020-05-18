<template>
  <div>
    {{$route.params}}
    <!-- <Menu :UserID="$route.params.UserID" /> -->
    <button @click="Goto">Back to Home</button>
    <ListVotings :User="$route.params"/>
  </div>
</template>

<script>
import ListVotings from "@/components/ListVotings.vue";
//import Menu from "@/components/Menu.vue";
export default {
	data(){
		return{
			
		}
	},
  methods: {
    Goto: function() {
      this.$router.push({ name: "Home", params: this.$route.params });
    }
  },
  components: {
    ListVotings,
    // Menu
  }
};
</script>