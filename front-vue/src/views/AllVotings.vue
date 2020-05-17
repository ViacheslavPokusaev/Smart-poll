<template>
  <div>
    <ListVotings v-bind:Filter="active"/>
    <router-link to="/">Log out</router-link>
  </div>
</template>

<script>
import ListVotings from "@/components/ListVotings.vue";
export default {
	data(){
		return{
			active: "active"
		}
	},
  components: {
    ListVotings
  }
};
</script>