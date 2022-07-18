import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";
import WebS from "../views/WebS.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/Home",
    name: "Home",
    component: Home,
  },
  {
    path: "/WebS",
    name: "WebS",
    component: WebS,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
