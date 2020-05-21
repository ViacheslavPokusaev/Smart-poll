<template>
  <span>До конца голосования - {{Timer}}</span>
</template>

<script>
export default {
  props: ["DeadLine"],
  name: "TimerPoll",
  data() {
    return {
      Timer: "Counting..."
    };
  },
  computed: {
    TimeLeft() {
      return this.Timer;
    }
  },
  created: function() {
    setInterval(() => this.GetTimer(), 1000);
  },
  methods: {
    GetTimer: function() {
      let DataDeadLine = new Date(Date.parse(this.DeadLine));
      let Millis = DataDeadLine - Date.now();

      let days = Millis / (1000 * 60 * 60 * 24);
      let absoluteDays = Math.floor(days);
      let d = absoluteDays > 9 ? absoluteDays : "0" + absoluteDays;

      let hours = (days - absoluteDays) * 24; //Millis / (1000 * 60 * 60);
      let absoluteHours = Math.floor(hours);
      let h = absoluteHours > 9 ? absoluteHours : "0" + absoluteHours;

      //Get remainder from hours and convert to minutes
      let minutes = (hours - absoluteHours) * 60;
      let absoluteMinutes = Math.floor(minutes);
      let m = absoluteMinutes > 9 ? absoluteMinutes : "0" + absoluteMinutes;

      //Get remainder from minutes and convert to seconds
      let seconds = (minutes - absoluteMinutes) * 60;
      let absoluteSeconds = Math.floor(seconds);
      let s = absoluteSeconds > 9 ? absoluteSeconds : "0" + absoluteSeconds;

      this.Timer = d + ":" + h + ":" + m + ":" + s;
    }
  }
};
</script>

<style scoped>
span {
	text-align: center;
  max-height: 24px;
}
</style>