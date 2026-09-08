// ─── Data ─── 

const products = [ 

  { id:1, name:"Bolo Red Velvet", price:"R$ 185,00", category:"bolos", rating:4.9, reviews:47, img:"photo-1578985545062-69928b1d9587", desc:"Massa aveludada com cream cheese artesanal" }, 

  { id:2, name:"Caixa de Trufas", price:"R$ 89,00", category:"doces", rating:5.0, reviews:83, img:"photo-1549007994-cb92caebd54b", desc:"12 unidades em sabores variados" }, 

  { id:3, name:"Torta de Limão", price:"R$ 130,00", category:"tortas", rating:4.8, reviews:62, img:"photo-1565958011703-44f9829ba187", desc:"Massa amanteigada, creme de limão siciliano" }, 

  { id:4, name:"Brigadeiros Gourmet", price:"R$ 65,00", category:"doces", rating:4.9, reviews:128, img:"photo-1571115177098-24ec42ed204d", desc:"Caixa com 20 unidades artesanais" }, 

  { id:5, name:"Bolo de Casamento", price:"R$ 580,00", category:"bolos", rating:5.0, reviews:34, img:"photo-1535254973040-607b474cb50d", desc:"3 andares, personalizado sob encomenda" }, 

  { id:6, name:"Macarons Franceses", price:"R$ 72,00", category:"doces", rating:4.7, reviews:55, img:"photo-1558326567-98ae2405596b", desc:"Caixa com 12 unidades, 6 sabores" }, 

  { id:7, name:"Cheesecake NY", price:"R$ 145,00", category:"tortas", rating:4.8, reviews:71, img:"photo-1533134242443-d4fd215305ad", desc:"Clássico americano com frutas vermelhas" }, 

  { id:8, name:"Bolo de Chocolate", price:"R$ 160,00", category:"bolos", rating:4.9, reviews:94, img:"photo-1606890737304-57a1ca8a5b62", desc:"Ganache 70% cacau, recheio triplo" }, 

]; 

// Pedidos: renderizados 100% no servidor (Views/Admin/index.cshtml), não há mais estado JS aqui.

const salesData = [ 

  { mes:"Jan", vendas:3200 }, { mes:"Fev", vendas:4100 }, { mes:"Mar", vendas:3800 }, 

  { mes:"Abr", vendas:5200 }, { mes:"Mai", vendas:4700 }, { mes:"Jun", vendas:6100 }, 

]; 

const services = [ 

  { imgUrl: 'https://images.unsplash.com/photo-1527515637467-5a2c1b0a6b58?w=200&h=200&fit=crop&auto=format', title:"Bolos de Casamento", desc:"Criações únicas e personalizadas para o dia mais especial. Degustação gratuita incluída.", price:"A partir de R$ 480" }, 

  { imgUrl: 'https://images.unsplash.com/photo-1544025162-d76694265947?w=200&h=200&fit=crop&auto=format', title:"Doces para Festas", desc:"Kits completos de bem-casados, docinhos e mesas de doces para eventos inesquecíveis.", price:"A partir de R$ 180" }, 

  { imgUrl: 'https://images.unsplash.com/photo-1523906834658-6e24ef238a5f?w=200&h=200&fit=crop&auto=format', title:"Encomendas Corporativas", desc:"Presenteie colaboradores e clientes com cestas e caixas premium personalizadas.", price:"A partir de R$ 120" }, 

  { imgUrl: 'https://images.unsplash.com/photo-1519744792095-2f2205e87b6f?w=200&h=200&fit=crop&auto=format', title:"Datas Especiais", desc:"Aniversários, Dia dos Namorados, Natal — criamos a lembrança perfeita para cada momento.", price:"A partir de R$ 85" }, 

]; 

 

// ─── State ─── 

let cartCount = 0; 

let currentCat = 'todos'; 

 

function stars(n) { 

  let h = ''; 

  for (let i = 1; i <= 5; i++) { 

    h += `<svg class="${i<=n?'star-full':'star-empty'}" viewBox="0 0 24 24" fill="${i<=n?'#f59e0b':'none'}" stroke="${i<=n?'#f59e0b':'#ccc'}" stroke-width="2" width="12" height="12"><polygon points="12 2 15.09 8.26 22 9.27 17 14.14 18.18 21.02 12 17.77 5.82 21.02 7 14.14 2 9.27 8.91 8.26 12 2"/></svg>`; 

  } 

// Atualiza badge do carrinho consultando o servidor
async function updateCartBadge() {
  try {
    const res = await fetch('/Carrinho/Quantidade');
    if (!res.ok) return;
    const data = await res.json();
    const count = data?.count || 0;
    const badge = document.querySelector('.cart-badge');
    if (!badge) return;
    if (count > 0) {
      badge.textContent = count;
      badge.style.display = 'inline-flex';
    } else {
      badge.textContent = '';
      badge.style.display = 'none';
    }
  } catch (e) {
    // ignore
  }
}

// Atualiza o badge periodicamente e ao carregar a página
document.addEventListener('DOMContentLoaded', function () {
  updateCartBadge();
  setInterval(updateCartBadge, 5000);
});

  return h; 

} 

 

function productCardHTML(p, showAdd=true) { 

  return ` 

    <div class="product-card"> 

      <div class="product-img-wrap"> 

        <img src="https://images.unsplash.com/${p.img}?w=400&h=300&fit=crop&auto=format" alt="${p.name}" loading="lazy" /> 

        <button class="product-fav" onclick="toggleFav(this)" title="Favoritar"> 

          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M20.84 4.61a5.5 5.5 0 0 0-7.78 0L12 5.67l-1.06-1.06a5.5 5.5 0 0 0-7.78 7.78l1.06 1.06L12 21.23l7.78-7.78 1.06-1.06a5.5 5.5 0 0 0 0-7.78z"/></svg> 

        </button> 

        <span class="product-cat">${p.category}</span> 

      </div> 

      <div class="product-body"> 

        <div class="product-name">${p.name}</div> 

        <div class="product-desc">${p.desc}</div> 

        <div class="product-meta"><div class="stars">${stars(Math.round(p.rating))}</div><span class="product-reviews">(${p.reviews})</span></div> 

        <div class="product-footer"> 

          <span class="product-price">${p.price}</span> 

          ${showAdd ? `<button class="add-btn" onclick="addToCart()"><svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" width="13" height="13"><line x1="12" y1="5" x2="12" y2="19"/><line x1="5" y1="12" x2="19" y2="12"/></svg>Adicionar</button>` : ''} 

        </div> 

      </div> 

    </div>`; 

} 

 

function toggleFav(btn) { 

  btn.classList.toggle('active'); 

  const svg = btn.querySelector('svg'); 

  if (btn.classList.contains('active')) { 

    svg.setAttribute('fill','#e53e3e'); svg.setAttribute('stroke','#e53e3e'); 

  } else { 

    svg.setAttribute('fill','none'); svg.setAttribute('stroke','currentColor'); 

  } 

} 

 

function addToCart() { 

  cartCount++; 

  const badge = document.getElementById('cart-badge'); 

  badge.textContent = cartCount; 

  badge.style.display = 'flex'; 

} 

 

// ─── Navigation ─── 

function navigate(page) { 

  document.querySelectorAll('.page').forEach(p => p.classList.remove('active')); 

  const target = document.getElementById('page-' + page); 

  if (target) { target.classList.add('active'); window.scrollTo(0,0); } 

 

  const isAdmin = page === 'admin'; 

  document.getElementById('nav').style.display = isAdmin ? 'none' : ''; 

  const atn = document.getElementById('admin-topnav'); 

  isAdmin ? atn.classList.add('show') : atn.classList.remove('show'); 

 

  // update nav active 

  ['home','loja','servicos','sobre','contato'].forEach(p => { 

    const nl = document.getElementById('nl-' + p); 

    const ml = document.getElementById('ml-' + p); 

    if (nl) nl.classList.toggle('active', p === page); 

    if (ml) ml.classList.toggle('active', p === page); 

  }); 

 

  if (page === 'loja') renderAllProducts(); 

} 

 

function toggleMenu() { 

  const m = document.getElementById('mobile-menu'); 

  m.classList.toggle('open'); 

} 

function closeMenu() { document.getElementById('mobile-menu').classList.remove('open'); } 

 

// ─── Products ─── 

function renderFeatured() { 

  const el = document.getElementById('featured-products'); 

  if (!el) return; 

  el.innerHTML = products.slice(0,4).map(p => productCardHTML(p)).join(''); 

} 

function renderAllProducts() { 

  filterProducts(); 

} 

function filterProducts() { 

  const q = (document.getElementById('search-input')?.value || '').toLowerCase(); 

  const filtered = products.filter(p => (currentCat === 'todos' || p.category === currentCat) && p.name.toLowerCase().includes(q)); 

  const el = document.getElementById('all-products'); 

  const nr = document.getElementById('no-results'); 

  if (!el) return; 

  if (filtered.length === 0) { el.innerHTML = ''; nr.style.display = 'block'; } 

  else { el.innerHTML = filtered.map(p => productCardHTML(p)).join(''); nr.style.display = 'none'; } 

} 

function setCat(cat, btn) { 

  currentCat = cat; 

  document.querySelectorAll('.cat-btn').forEach(b => b.classList.remove('active')); 

  btn.classList.add('active'); 

  filterProducts(); 

} 

 

// ─── Services ─── 

function renderServices() { 

  const el = document.getElementById('services-preview'); 

  if (!el) return; 

  el.innerHTML = services.map(s => ` 

    <div class="service-card"> 

      <div class="service-icon"><img src="${s.imgUrl}" alt="" loading="lazy" width="48" height="48" onerror="this.onerror=null;this.src='https://via.placeholder.com/48?text=+'"/></div> 

      <div class="service-title">${s.title}</div> 

      <div class="service-desc">${s.desc}</div> 

      <div class="service-price">${s.price}</div> 

    </div>`).join(''); 

} 

 

// ─── Forms ─── 

function submitContato(e) { 

  e.preventDefault(); 

  document.getElementById('contato-form-wrap').innerHTML = ` 

    <div class="success-box"> 

      <svg class="success-icon" viewBox="0 0 24 24" fill="none" stroke="var(--accent)" stroke-width="2"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg> 

      <h3>Mensagem enviada!</h3> 

      <p>Entraremos em contato em até 24 horas.</p> 

      <button class="btn btn-primary" style="margin-top:1.5rem" onclick="resetContato()">Nova mensagem</button> 

    </div>`; 

} 

function resetContato() { navigate('contato'); } 

 

function submitLogin(e) { e.preventDefault(); navigate('admin'); } 

function submitCadastro(e) { 

  e.preventDefault(); 

  document.getElementById('cadastro-wrap').innerHTML = ` 

    <div class="success-box"> 

      <svg class="success-icon" viewBox="0 0 24 24" fill="none" stroke="var(--accent)" stroke-width="2"><path d="M22 11.08V12a10 10 0 1 1-5.93-9.14"/><polyline points="22 4 12 14.01 9 11.01"/></svg> 

      <h3>Conta criada!</h3> 

      <p style="color:var(--muted-fg);font-size:0.9rem;margin-bottom:1.5rem">Bem-vinda ao DoceCantinho! Verifique seu e-mail para confirmar o cadastro.</p> 

      <button class="btn btn-primary" onclick="navigate('login')">Fazer Login</button> 

    </div>`; 

} 

 

// ─── Admin ─── 

function adminTab(tab) { 

  ['dashboard','pedidos','produtos','clientes'].forEach(t => { 

    document.getElementById('atab-' + t).style.display = t === tab ? '' : 'none'; 

    const nb = document.getElementById('anb-' + t); 

    if (nb) nb.classList.toggle('active', t === tab); 

    const mb = document.getElementById('atm-' + t); 

    if (mb) mb.classList.toggle('active', t === tab); 

  }); 

  const titles = { dashboard:'Dashboard', pedidos:'Pedidos', produtos:'Produtos', clientes:'Clientes' }; 

  document.getElementById('admin-title').textContent = titles[tab]; 

} 

 

function renderAdmin() { 

  // Bar chart 

  var barChartEl = document.getElementById('bar-chart'); 

  if (barChartEl) { 

    const maxVal = Math.max(...salesData.map(d=>d.vendas)); 

    barChartEl.innerHTML = salesData.map(d => ` 

      <div class="bar-month"> 

        <div class="bar" style="height:${Math.round((d.vendas/maxVal)*140)}px" title="${d.mes}: R$ ${d.vendas.toLocaleString()}"></div> 

        <div class="bar-label">${d.mes}</div> 

      </div>`).join(''); 

  } 

 

 

  // Admin products 

  var adminProductsGridEl = document.getElementById('admin-products-grid'); 

  if (adminProductsGridEl) adminProductsGridEl.innerHTML = products.map(p => ` 

    <div class="admin-product-card"> 

      <div class="admin-product-img"> 

        <img src="https://images.unsplash.com/${p.img}?w=400&h=200&fit=crop&auto=format" alt="${p.name}" loading="lazy" /> 

        <span class="admin-product-cat">${p.category}</span> 

      </div> 

      <div class="admin-product-body"> 

        <div class="admin-product-head"> 

          <span class="admin-product-name">${p.name}</span> 

          <span class="admin-product-price">${p.price}</span> 

        </div> 

        <div class="product-meta" style="margin-bottom:0"><div class="stars">${stars(Math.round(p.rating))}</div><span class="product-reviews">(${p.reviews})</span></div> 

        <div class="admin-product-actions"> 

          <button class="edit-btn"> 

            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" width="12" height="12"><path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"/><path d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"/></svg>Editar 

          </button> 

          <button class="delete-btn"> 

            <svg viewBox="0 0 24 24" fill="none" stroke="#ef4444" stroke-width="2" width="13" height="13"><polyline points="3 6 5 6 21 6"/><path d="M19 6l-1 14a2 2 0 0 1-2 2H8a2 2 0 0 1-2-2L5 6"/><path d="M10 11v6m4-6v6"/><path d="M9 6V4a1 1 0 0 1 1-1h4a1 1 0 0 1 1 1v2"/></svg> 

          </button> 

        </div> 

      </div> 

    </div>`).join(''); 

 

  // Clientes table 

  const clientes = [ 

    { name:"Ana Oliveira", email:"ana.oliveira@email.com", tel:"(11) 98765-4321", orders:8, total:"R$ 1.240,00", since:"Mar 2024" }, 

    { name:"Carlos Mendes", email:"carlos.m@email.com", tel:"(11) 91234-5678", orders:23, total:"R$ 2.967,00", since:"Jan 2023" }, 

    { name:"Maria Santos", email:"mssantos@email.com", tel:"(11) 99988-7766", orders:5, total:"R$ 845,00", since:"Jun 2025" }, 

    { name:"Pedro Lima", email:"pedro.lima@email.com", tel:"(11) 92233-4455", orders:12, total:"R$ 1.890,00", since:"Ago 2023" }, 

    { name:"Juliana Costa", email:"ju.costa@email.com", tel:"(11) 95544-3322", orders:19, total:"R$ 3.410,00", since:"Nov 2022" }, 

  ]; 

  // Se a view servidor já forneceu o conteúdo (data-server="1"), não sobrescrever
  const clientesEl = document.getElementById('clientes-table');
  if (!clientesEl || clientesEl.dataset.server === '1') {
    return;
  }

  clientesEl.innerHTML = ` 

    <table class="data-table"> 

      <thead><tr><th>Cliente</th><th>E-mail</th><th>Telefone</th><th style="text-align:center">Pedidos</th><th>Total gasto</th><th>Desde</th></tr></thead> 

      <tbody> 

        ${clientes.map(c => { 

          const initials = c.name.split(' ').map(n=>n[0]).join('').slice(0,2); 

          return `<tr> 

            <td><div class="cliente-name-cell"><div class="cliente-avatar">${initials}</div><strong>${c.name}</strong></div></td> 

            <td style="color:var(--muted-fg);font-size:0.8rem">${c.email}</td> 

            <td style="color:var(--muted-fg);font-size:0.8rem">${c.tel}</td> 

            <td style="text-align:center;font-weight:700">${c.orders}</td> 

            <td style="font-weight:700;color:var(--accent)">${c.total}</td> 

            <td style="color:var(--muted-fg);font-size:0.8rem">${c.since}</td> 

          </tr>`; 

        }).join('')} 

      </tbody> 

    </table>`; 

} 

 

// ─── Init ─── 

renderFeatured(); 

renderServices(); 

renderAdmin(); 
// ─── Override adminTab for Razor views ───
function adminTab(tab) {
  ['dashboard','pedidos','produtos','categorias','clientes'].forEach(t => {
    const el = document.getElementById('atab-' + t);
    if (el) el.classList.toggle('active', t === tab);
    const nb = document.getElementById('anb-' + t);
    if (nb) nb.classList.toggle('active', t === tab);
  });
  const titleEl = document.getElementById('admin-title');
  if (titleEl) {
    const titles = { dashboard:'Dashboard', pedidos:'Pedidos', produtos:'Produtos', categorias:'Categorias', clientes:'Clientes' };
    titleEl.textContent = titles[tab] || '';
  }
}


// Avaliações da Home: seleção de estrelas e confirmação local.
document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".star-picker").forEach(function (picker) {
        const hidden = document.getElementById(
            picker.dataset.rating === "sweet" ? "sweet-rating" : "site-rating"
        );

        function paint(value) {
            picker.querySelectorAll("button").forEach(function (button) {
                button.classList.toggle("selected", Number(button.dataset.value) <= value);
            });
        }

        picker.querySelectorAll("button").forEach(function (button) {
            button.addEventListener("click", function () {
                const value = Number(button.dataset.value);
                hidden.value = value;
                paint(value);
            });
        });

        paint(Number(hidden.value || 5));
    });

    const form = document.getElementById("review-form");
    const success = document.getElementById("review-success");

    if (form && success) {
        form.addEventListener("submit", function (event) {
            event.preventDefault();
            if (!form.checkValidity()) {
                form.reportValidity();
                return;
            }

            const data = {
                name: form.name.value.trim(),
                email: form.email.value.trim(),
                sweetRating: form.sweetRating.value,
                siteRating: form.siteRating.value,
                message: form.message.value.trim(),
                createdAt: new Date().toISOString()
            };

            const reviews = JSON.parse(localStorage.getItem("docecantinho-reviews") || "[]");
            reviews.unshift(data);
            localStorage.setItem("docecantinho-reviews", JSON.stringify(reviews.slice(0, 20)));

            form.reset();
            document.getElementById("sweet-rating").value = 5;
            document.getElementById("site-rating").value = 5;
            document.querySelectorAll(".star-picker").forEach(function (picker) {
                picker.querySelectorAll("button").forEach(function (button) {
                    button.classList.toggle("selected", Number(button.dataset.value) <= 5);
                });
            });

            success.classList.add("show");
            setTimeout(function () { success.classList.remove("show"); }, 5000);
        });
    }
});

/* =========================================================
   DARK MODE / LIGHT MODE
   ========================================================= */

(function () {
    const savedTheme = localStorage.getItem('docecantinho-theme');

    const systemPrefersDark =
        window.matchMedia &&
        window.matchMedia('(prefers-color-scheme: dark)').matches;

    const theme =
        savedTheme ||
        (systemPrefersDark ? 'dark' : 'light');

    document.documentElement.setAttribute('data-theme', theme);
})();

function toggleTheme() {
    const html = document.documentElement;

    const currentTheme =
        html.getAttribute('data-theme') || 'light';

    const newTheme =
        currentTheme === 'dark'
            ? 'light'
            : 'dark';

    html.setAttribute('data-theme', newTheme);

    localStorage.setItem(
        'docecantinho-theme',
        newTheme
    );

    updateThemeButton();
}

function updateThemeButton() {
    const html = document.documentElement;

    const theme =
        html.getAttribute('data-theme') || 'light';

    const button =
        document.getElementById('theme-toggle');

    const text =
        document.getElementById('theme-text');

    if (!button) {
        return;
    }

    if (theme === 'dark') {

        button.setAttribute(
            'aria-label',
            'Ativar tema claro'
        );

        button.setAttribute(
            'title',
            'Ativar tema claro'
        );

        if (text) {
            text.textContent = 'Claro';
        }

    } else {

        button.setAttribute(
            'aria-label',
            'Ativar tema escuro'
        );

        button.setAttribute(
            'title',
            'Ativar tema escuro'
        );

        if (text) {
            text.textContent = 'Escuro';
        }
    }
}

document.addEventListener(
    'DOMContentLoaded',
    function () {
        updateThemeButton();
    }
);

