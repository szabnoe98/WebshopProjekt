<template>
  <div id="nav">
    <router-link to="/Home">Home</router-link>
  </div>
  <router-view />
</template>

<style>
:root {
  --pink: #4d3b30;
}

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  outline: none;
  border: none;
  text-decoration: none;
  text-transform: capitalize;
  transition: 0.2s linear;
}

html {
  font-size: 62.5%;
  scroll-behavior: smooth;
  scroll-padding-top: 6rem;
  overflow-x: hidden;
}

section {
  padding: 2rem 9%;
}

.heading {
  text-align: left;
  font-size: 4rem;
  color: rgb(142, 50, 16);
  padding: 1rem;
  margin: 2rem 0;
  background: rgb(255, 235, 227);
}

.btn {
  display: inline-block;
  margin-top: 1rem;
  border-radius: 5rem;
  background: #333;
  color: #fff;
  padding: 0.9rem 3.5rem;
  cursor: pointer;
  font-size: 1.7rem;
}

header {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  background: #fff;
  padding: 2rem 9%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  z-index: 1000;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.1);
}

header .logo {
  font-size: 3rem;
  color: #333;
  font-weight: bolder;
}

header .logo span {
  color: var(--pink);
}

header .navbar a {
  font-size: 2rem;
  padding: 0 1.5rem;
  color: #666;
}

header .navbar a:hover {
  color: var(--pink);
}

header .allando a {
  font-size: 2.5rem;
  color: #333;
  margin-left: 1.5rem;
}

header .allando a:hover {
  color: var(--pink);
}

header #toggler {
  display: none;
}

header .fa-bars {
  font-size: 3rem;
  color: #333;
  border-radius: 0.5rem;
  padding: 0.5rem 1.5rem;
  cursor: pointer;
  border: 0.1rem solid rgba(0, 0, 0, 0.3);
  display: none;
}

.kezdolap {
  display: flex;
  align-items: center;
  min-height: 65vh;
  background: url(../src/assets/Sós.jpg) no-repeat;
  background-size: cover;
  background-position: right;
}

.kezdolap .tartalom {
  max-width: 30rem;
}

.kezdolap .tartalom h3 {
  font-size: 6rem;
  color: rgb(240, 121, 77);
  text-shadow: -2px -2px 0 #000, 2px -2px 0 #000, -2px 2px 0 #000,
    2px 2px 0 #000;
}

.kezdolap .tartalom span {
  font-size: 3.5rem;
  color: var(--pink);
  padding: 1rem 0;
  line-height: 1.5;
}

.kezdolap .tartalom p {
  font-size: 1.5rem;
  color: rgb(252, 252, 252);
  text-shadow: -2px -2px 0 #000, 2px -2px 0 #000, -2px 2px 0 #000,
    2px 2px 0 #000;
  padding: 1rem 0;
  line-height: 1.5;
}

.mindigallando {
  background: rgb(255, 235, 227);
  display: flex;
  flex-wrap: wrap;
  gap: 1.5rem;
  padding-top: 5rem;
  padding-bottom: 5rem;
}

.mindigallando .allando {
  background: #fff;
  border: 0.1rem solid rgba(0, 0, 0, 0.1);
  padding: 2rem;
  display: flex;
  align-items: center;
  flex: 1 1 25rem;
}

.mindigallando .allando img {
  height: 5rem;
  margin-right: 2rem;
}

.mindigallando .allando h3 {
  color: #333;
  padding-bottom: 0.5rem;
  font-size: 1.5rem;
}

.mindigallando .allando span {
  color: #555;
  font-size: 1.3rem;
}

.termekek .box-container {
  display: flex;
  flex-wrap: wrap;
  gap: 1.5rem;
}

.termekek .box-container .box {
  flex: 1 1 30rem;
  box-shadow: 0 0.5rem 1.5rem rgba(0, 0, 0, 0.1);
  border-radius: 0.5rem;
  border: 0.1rem solid rgba(0, 0, 0, 0.1);
  position: relative;
}

.termekek .box-container .box .discount {
  position: absolute;
  top: 1rem;
  left: 1rem;
  padding: 0.7rem 1rem;
  font-size: 2rem;
  background: rgba(255, 51, 153, 0.05);
  z-index: 1;
  border-radius: 0.5rem;
}

.termekek .box-container .box .image {
  position: relative;
  text-align: center;
  padding-top: 2rem;
  overflow: hidden;
}

.termekek .box-container .box .image img {
  height: 25rem;
}

.termekek .box-container .box:hover .image img {
  transform: scale(1.1);
}

.termekek .box-container .box .image .allando {
  position: absolute;
  bottom: -7rem;
  left: 0;
  right: 0;
  display: flex;
}

.termekek .box-container .box:hover .image .allando {
  bottom: 0;
}

.termekek .box-container .box .image .allando a {
  height: 5rem;
  line-height: 5rem;
  font-size: 2rem;
  width: 50%;
  background: var(--pink);
  color: #fff;
}

.termekek .box-container .box .image .allando .cart-btn {
  border-left: 0.1rem solid #fff7;
  border-right: 0.1rem solid #fff7;
  width: 100%;
}

.termekek .box-container .box .image .allando a:hover {
  background: #333;
}

.termekek .box-container .box .tartalom {
  padding: 2rem;
  text-align: center;
}

.termekek .box-container .box .tartalom h3 {
  font-size: 2.5rem;
  color: #333;
}

.termekek .box-container .box .tartalom .ar {
  font-size: 2.5rem;
  color: var(--pink);
  font-weight: bolder;
  padding-top: 1rem;
}

.termekek .box-container .box .tartalom .ar span {
  font-size: 1.5rem;
  color: #999;
  font-weight: lighter;
  text-decoration: line-through;
}

@media (max-width: 991px) {
  html {
    font-size: 55%;
  }

  header {
    padding: 2rem;
  }

  section {
    padding: 2rem;
  }

  .kezdolap {
    background-position: left;
  }

  .tarolo {
    background-position: left;
  }
}

@media (max-width: 768px) {
  header .fa-bars {
    display: block;
  }

  header .navbar {
    position: absolute;
    top: 100%;
    left: 0;
    right: 0;
    background: rgb(255, 235, 227);
    border-top: 0.1rem solid rgba(0, 0, 0, 0.1);
    clip-path: polygon(0 0, 100% 0, 100% 0, 0 0);
    padding: 50px;
  }

  .dropdown-content {
    position: relative;
  }

  header #toggler:checked ~ .navbar {
    clip-path: polygon(0 0, 100% 0, 100% 100%, 0% 100%);
    color: #000;
  }

  header .navbar .dropdown {
    padding: 1rem;
    background: #fff;
    border: 0.1rem solid rgba(0, 0, 0, 0.1);
    display: block;
  }

  header .navbar a {
    padding: 1.5rem;
    background: #fff;
    border: 0.1rem solid rgba(0, 0, 0, 0.1);
    display: block;
  }

  .kezdolap .tartalom h3 {
    font-size: 5rem;
  }

  .kezdolap .tartalom span {
    font-size: 2.5rem;
  }

  .mindigallando .allando h3 {
    font-size: 2rem;
  }

  .mindigallando .allando span {
    font-size: 1.7rem;
  }
}

@media (max-width: 450px) {
  html {
    font-size: 50%;
  }

  .heading {
    font-size: 3rem;
  }
}
.dropbtn {
  font-size: 2rem;
  padding: 5px;
  color: #666;
  background-color: white;
  border: none;
}

.dropdown {
  position: relative;
  display: inline-block;
  font-size: 2rem;
  padding: 0 1.5rem;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
  font-size: 2rem;
  padding: 0 1.5rem;
}

.dropdown-content a {
  color: black;
  text-decoration: none;
  display: block;
  font-size: 2rem;
  padding: 0 1.5rem;
}


.dropdown-content a:hover {
  background-color: #ddd;
  display: flex;
}


.dropdown:hover .dropdown-content {
  display: block;
}

.dropdown:hover .dropbtn {
  background-color: rgb(212, 146, 122);
}

.cim {
  text-align: right;
  font-size: 4rem;
  color: rgb(142, 50, 16);
  padding: 2rem;
  margin: 5rem 0;
  background: rgb(255, 235, 227);
}

.tarolo {
  margin-top: 150px;
}

.newarrival {
  background: orange;
  width: 50px;
  color: white;
  font-size: 12px;
}

.col-md-7 {
  color: #555;
}

.arazas {
  color: #fe980f;
  font-size: 26px;
  font-weight: bold;
  padding-top: 20px;
}

input {
  border: 1px solid #ccc;
  font-weight: bold;
  height: 33px;
  text-align: center;
  width: 30px;
}

.cart {
  background: #fe980f;
  color: #ffff;
  font-size: 15px;
  margin-left: 20px;
}

.col-fixed-right {
  background-color: rgb(255, 235, 227);
  margin-bottom: 30px;
  border: #000;
  font-size: 15px;
  width: 15%;
}
</style>
