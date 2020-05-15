<template>
  <div>
    <ListVotings />
    <router-link to="/">Home</router-link>
  </div>
</template>

<script>
import ListVotings from "@/components/ListVotings.vue";
export default {
  components: {
    ListVotings
  }
};
</script>