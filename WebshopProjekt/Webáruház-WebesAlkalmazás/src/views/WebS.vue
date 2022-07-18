<template>
  <header>
    <input type="checkbox" name="" id="toggler" />
    <label for="toggler" class="fas fa-bars"></label>

    <a href="#" class="logo">Ica Bolt</a>

    <nav class="navbar">
      <a href="#"><router-link to="/Home">Főoldal</router-link></a>
      <a href="#">Rólunk</a>
      <div class="dropdown">
        <button class="dropbtn">Kiemelt ajánlatunk</button>
        <div class="dropdown-content">
          <a> <router-link to="/WebS">E heti kedvenc</router-link></a>
          <a href="#">Korábbi akcióink</a>
      </div>
      </div>
      <a href="#">Rólunk</a>
      <a href="#">Kapcsolat</a>
    </nav>

    <div class="allando">
      <h1 class="nyitva">Nyitvatartás: Mindennap 7:00-19:00</h1>
    </div>
  </header>

  <div class="tarolo">
    <div class="col left">
      <div class="col-md-5"></div>
      <div class="col-md-7" style="float: left">
        <img src="@/assets/Akcio-Malnalekv-Masodik.jpg" class="fankmalna" />
        <p class="newarrival text-center">Akció!</p>
        <div v-for="cikkszam in termek" :key="cikkszam.cikkszam">
          <h1>{{ cikkszam.cikknev }}</h1>

          <p><b>Leírás:</b></p>
          <p>
            <b
              >Búzaliszt, Málna lekvár (25%) (málna (50%), fruktózszirup, cukor,
              ivóvíz, sűrítőanyag (pektinek), sav (citromsav), aroma, színezék
              (kapszantin)), Ivóvíz, Fánk keverék (búzaliszt, cukor,
              tejfehérjék, pálmazsír por [pálmaolaj, glükózszirup, tejfehérjék],
              szárított tojásfehérje, tojáspor, só, emulgeálószer (lecitinek
              (glutén, zsírsavak mono- és digliceridjei, zsírsavak mono- és
              digliceridjeinek mono- és diacetil borkősav észterei), búzaglutén,
              aroma, savasságot szabályozó anyag (kalcium-foszfátok), színezék
              (karotinok), sűrítőanyag (guargumi), lisztkezelő szer
              (aszkorbinsav, L-cisztein)), Sütőolaj (teljes mértékben finomított
              növényi olajok (szójababolaj, pálmaolaj), aroma, habosodásgátló
              anyag (dimetil-polisziloxán)), Dekor porcukor (dextróz,
              búzakeményítő, teljes tejpor, aroma), Margarin (pálmazsír,
              repceolaj, napraforgóolaj, ivóvíz, só, emulgeálószer (zsírsavak
              mono- és digliceridjei), sav (citromsav), színezék (karotinok),
              aroma), Élesztő, Burgonya dextrin, Cékla koncentrátum
              (maltodextrin, cékla koncentrátum, citromsav)</b
            >
          </p>
          <p class="arazas">{{ cikkszam.beszerzesi_ar }} Ft</p>
          <button
            type="button"
            class="btn btn-default cart"
            @click="addToCart(cikkszam, 1)">
            Kosárba tesz
          </button>
        </div>
      </div>
    </div>
    <div class="col-fixed-right">
      <p>
        <b><strong>Kosár tartalma</strong></b>
      </p>
      <div v-for="cikkszam in rendeles" :key="cikkszam.cikkszam">
        Név: {{ cikkszam.megnevezes }}<br />Ár: {{ cikkszam.beszerzesi_ar }} Ft
        <div>
          <button
            type="button"
            class="btn btn-default cart"
            @click="removeFromCart(cikkszam)">
            Tétel eltávolítása
          </button>
        </div>
        <div>Összérték: {{ osszertek }}</div>
      </div>
      <div>
         <label for="email">Adja meg e-mail címét</label>
            <input class="emailinput"
            id="email"
            v-model="email"
            type="email"
            name="email"
          >
        <br />
        <button type="button" class="btn btn-default cart" @click="buy()">
          Vásárlás
        </button>
      </div>
    </div>
  </div>
</template>

<script>
//import axios from 'axios';

export default {
  name: "Post",
  components: {
    //Form,
  },
  data() {
    return {
      termek: [
        {
          cikkszam: 70836,
          cikknev: "Málnalekváros fánk",
          beszerzesi_ar: 39,
          mennyiseg: 1,
        },
      ],

      rendelesi_tetelek: [
        {
          rendelesi_tetelek_id: null,
          rendelesi_id: null,
          cikkszam: 70836,
          mennyiseg: 1,
        },
      ],

      rendeles: [],
      osszertek: 0,

      errors: [],
      email: null,
    };
  },
  computed: {},
  methods: {
    mounted() {
      fetch("http://localhost:5000/api/termek/70836")
        .then((res) => res.json())
        .then((data) => (this.cikknev = data));
    },
    addToCart(cikkszam, darabszam) {
      console.log(cikkszam);
      this.rendeles.push({
        cikkszam: cikkszam.cikkszam,
        mennyiseg: darabszam,
        megnevezes: cikkszam.cikknev,
        beszerzesi_ar: cikkszam.beszerzesi_ar,
      });
      this.osszertek += cikkszam.beszerzesi_ar * cikkszam.mennyiseg;
    },
    removeFromCart(cikkszam) {
      this.rendeles.splice(this.rendeles.indexOf(cikkszam), 70836);
      this.osszertek -= cikkszam.beszerzesi_ar;
    },
    buy() {
      fetch("http://localhost:5000/api/rendeles", {
        method: "POST",
        body: JSON.stringify({
          vasarlo_id: 7,
          rendelesi_tetelek: this.rendeles,
        }),
        headers: {
          "Content-Type": "application/json",
        },
      })
        .then((response) => response.json())
        .then((result => alert("Rendelését rögzítettük!" + result)))
        .catch((error) => {
          console.error("Error:", error);
        });
    },
    checkForm: function (e) {
      this.errors = [];

      if (!this.email) {
        this.errors.push('Email required.');
      } else if (!this.validEmail(this.email)) {
        this.errors.push('Valid email required.');
      }
      if (!this.errors.length) {
        return true;
      }

      e.preventDefault();
    },
    validEmail: function (email) {
      var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
      return re.test(email);
    }
  }
}

</script>

<style>
.tarolo {
  display: flex;
  justify-content: center;
  align-items: stretch;
  flex-direction: row;
  flex-wrap: wrap;
}
.fixed {
  top: 0;
  right: 0;
}
.left {
  width: 70%;
}
.right {
  width: 30%;
}

.nyitva {
  text-align: right;
  font-size: 15px;
  margin-left: 20px;
}
.fankmalna {
  float: right;
}

.emailinput {
  width: 200px;
  align-content: center;
  text-transform: lowercase;
}
</style>
