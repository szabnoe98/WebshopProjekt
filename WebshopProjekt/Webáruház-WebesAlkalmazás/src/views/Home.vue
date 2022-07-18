<template>
  <header>
    <input type="checkbox" name="" id="toggler" />
    <label for="toggler" class="fas fa-bars"></label>
    <a href="#" class="logo">Ica Bolt</a>

    <nav class="navbar">
      <a href="#"><router-link to="/Home">Főoldal</router-link></a>
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
  <section class="kezdolap" id="kezdolap">
    <div class="tartalom">
      <h3>Szezonális Sütemény akciók!</h3>
      <p>
        Rendelje meg kedvenc termékeit, és vegye át egyben!
        <br />Címünk: 6763, Szatymaz, Jánosszállási kertsor 152
        <br />Telefonszámunk: +36 20/ 123-1234
      </p>
      <a href="#" class="btn">Adja le rendelését!</a>
    </div>
  </section>

  <section class="mindigallando">
    <div class="allando">
      <img src="../assets/Allando-Barna.jpg" alt="" />
      <div class="info">
        <h3>Sajtos-Bacononos Csavart 70g</h3>
        <span>120 Ft</span>
      </div>
    </div>

    <div class="allando">
      <img src="../assets/Allando-Kakaos.png" />
      <div class="info">
        <h3>Kakaós kalács 500g</h3>
        <span>380 Ft</span>
      </div>
    </div>

    <div class="allando">
      <img src="../assets/Allando-Barna.jpg" alt="" />
      <div class="info">
        <h3>Barna kenyér 1kg</h3>
        <span>420 Ft</span>
      </div>
    </div>
  </section>

  <section class="termekek" id="termekek">
    <h1 class="heading">Szenzációs <span>Ajánlat</span></h1>

    <div class="box-container">
      <div class="box">
        <div class="image">
          <span class="discount">Akció!</span>
          <img src="../assets/Akcio-Szatmari.png" alt="" />
          <div class="allando">
            <a href="#" class="cart-btn">Kosárba Teszem</a>
          </div>
        </div>
        <div class="tartalom">
          <h3>Szatmári finomliszt 1kg</h3>
          <div class="ar">120 Ft <span>137 Ft</span></div>
        </div>
      </div>

      <div class="box">
        <span class="discount">Akció!</span>
        <div class="image">
          <img src="../assets/Akcio-Familia.png" alt="" />
          <div class="allando">
            <a href="#" class="cart-btn">Kosárba Teszem</a>
          </div>
        </div>
        <div class="tartalom">
          <h3>Famíliatészta Durum Orsó 400g</h3>
          <div class="ar">380 Ft <span>434 Ft</span></div>
        </div>
      </div>

      <div class="box">
        <span class="discount">Akció!</span>
        <div class="image">
          <img src="../assets/Akcio-Tolle.jpg" alt="" />
          <div class="allando">
            <a href="#" class="cart-btn">Kosárba Teszem</a>
          </div>
        </div>
        <div class="tartalom">
          <h3>Tolle Tejföl 20 % 325g</h3>
          <div class="ar">156 Ft <span>178 Ft</span></div>
        </div>
      </div>

      <div class="box">
        <span class="discount">Akció!</span>
        <div class="image">
          <img src="../assets/Akcio-Malnalekv.jpg" alt="" />
          <div class="allando">
            <a href="#" class="cart-btn">Kosárba Teszem</a>
          </div>
        </div>
        <div class="tartalom">
          <a href="#"
            ><h3>
              <router-link to="/WebS">Málnalekváros fánk 75g</router-link>
            </h3></a
          >
          <div class="ar">39 Ft <span>45 Ft</span></div>
        </div>
      </div>
    </div>
  </section>
  <section>
    <div class="credit">Készítette: Szabácsi Noémi és Imrő-Bárkányi Erika</div>
  </section>
</template>