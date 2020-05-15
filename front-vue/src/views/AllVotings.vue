<template>
  <div>
    <ListVotings />
    <a href="/Home">Home</a>
  </div>
</template>

<script>
import ListVotings from "@/components/ListVotings.vue";
export default {
  name: "home",
  components: {
    ListVotings
  }
};
</script>