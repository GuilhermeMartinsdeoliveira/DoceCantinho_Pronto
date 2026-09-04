/* =============================================================================
 * Carrossel Dinâmico — Doce Cantinho
 * =============================================================================
 * Um carrossel genérico que monta os slides em tempo de execução (JS), a
 * partir de uma lista de dados (array de objetos). Isso é o que o torna
 * "dinâmico": não é um punhado de <div> fixos no HTML — é gerado por código.
 *
 * COMO ADICIONAR UM SLIDE DE VÍDEO
 * ---------------------------------
 * Abra a view onde o carrossel é usado (ex.: Views/Home/Index.cshtml) e
 * procure o bloco <script type="application/json" id="carousel-data">.
 * Adicione um novo objeto ao array, por exemplo:
 *
 *   {
 *     "type": "video",
 *     "src": "/videos/producao-bolo.mp4",   // arquivo em wwwroot/videos/
 *     "poster": "/videos/producao-bolo.jpg", // capa exibida antes do play
 *     "title": "Veja como preparamos nossos bolos",
 *     "caption": "Direto da nossa cozinha, com carinho em cada etapa."
 *   }
 *
 * Para um slide de imagem, use:
 *
 *   {
 *     "type": "image",
 *     "src": "https://.../foto.jpg",
 *     "title": "Título do slide",
 *     "caption": "Legenda opcional."
 *   }
 *
 * Nenhuma alteração de código é necessária — o carrossel lê o array e
 * desenha os slides sozinho, na ordem em que aparecem.
 * =============================================================================
 */

(function () {
    "use strict";

    function initCarousel(root) {
        var dataEl = root.querySelector("script[data-carousel-json]");
        if (!dataEl) return;

        var slides;
        try {
            slides = JSON.parse(dataEl.textContent);
        } catch (e) {
            console.error("Carrossel: JSON de slides inválido.", e);
            return;
        }
        if (!Array.isArray(slides) || slides.length === 0) return;

        var track = root.querySelector(".mm-carousel-track");
        var dotsWrap = root.querySelector(".mm-carousel-dots");
        var prevBtn = root.querySelector(".mm-carousel-prev");
        var nextBtn = root.querySelector(".mm-carousel-next");
        var autoplayMs = parseInt(root.getAttribute("data-autoplay") || "6000", 10);

        var current = 0;
        var timer = null;
        var slideEls = [];

        // ─── Monta os slides dinamicamente ───
        slides.forEach(function (slide, index) {
            var slideEl = document.createElement("div");
            slideEl.className = "mm-carousel-slide";
            slideEl.setAttribute("role", "group");
            slideEl.setAttribute("aria-roledescription", "slide");
            slideEl.setAttribute("aria-label", (index + 1) + " de " + slides.length);

            var mediaEl;
            if (slide.type === "video") {
                mediaEl = document.createElement("video");
                mediaEl.src = slide.src;
                if (slide.poster) mediaEl.poster = slide.poster;
                mediaEl.controls = true;
                mediaEl.playsInline = true;
                mediaEl.preload = "metadata";
                mediaEl.className = "mm-carousel-media";

                mediaEl.addEventListener("play", function () {
                    stopAutoplay();
                });
                mediaEl.addEventListener("pause", function () {
                    startAutoplay();
                });
                mediaEl.addEventListener("ended", function () {
                    startAutoplay();
                    goTo(current + 1);
                });

                var badge = document.createElement("span");
                badge.className = "mm-carousel-video-badge";
                badge.innerHTML = '<svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" width="14" height="14"><polygon points="5 3 19 12 5 21 5 3"/></svg> Vídeo';
                slideEl.appendChild(badge);
            } else {
                mediaEl = document.createElement("img");
                mediaEl.src = slide.src;
                mediaEl.alt = slide.title || "";
                mediaEl.loading = index === 0 ? "eager" : "lazy";
                mediaEl.className = "mm-carousel-media";
            }
            slideEl.appendChild(mediaEl);

            if (slide.title || slide.caption) {
                var caption = document.createElement("div");
                caption.className = "mm-carousel-caption";
                if (slide.title) {
                    var h = document.createElement("h3");
                    h.textContent = slide.title;
                    caption.appendChild(h);
                }
                if (slide.caption) {
                    var p = document.createElement("p");
                    p.textContent = slide.caption;
                    caption.appendChild(p);
                }
                slideEl.appendChild(caption);
            }

            track.appendChild(slideEl);
            slideEls.push(slideEl);

            if (dotsWrap) {
                var dot = document.createElement("button");
                dot.type = "button";
                dot.className = "mm-carousel-dot";
                dot.setAttribute("aria-label", "Ir para o slide " + (index + 1));
                dot.addEventListener("click", function () {
                    goTo(index);
                    restartAutoplay();
                });
                dotsWrap.appendChild(dot);
            }
        });

        var dotEls = dotsWrap ? Array.prototype.slice.call(dotsWrap.children) : [];

        function render() {
            track.style.transform = "translateX(-" + (current * 100) + "%)";
            dotEls.forEach(function (d, i) {
                d.classList.toggle("active", i === current);
            });
            // Pausa qualquer vídeo que não esteja no slide ativo
            slideEls.forEach(function (el, i) {
                var video = el.querySelector("video");
                if (video && i !== current && !video.paused) {
                    video.pause();
                }
            });
        }

        function goTo(index) {
            current = ((index % slides.length) + slides.length) % slides.length;
            render();
        }

        function startAutoplay() {
            if (autoplayMs <= 0) return;
            stopAutoplay();
            timer = setInterval(function () { goTo(current + 1); }, autoplayMs);
        }

        function stopAutoplay() {
            if (timer) {
                clearInterval(timer);
                timer = null;
            }
        }

        function restartAutoplay() {
            stopAutoplay();
            startAutoplay();
        }

        if (prevBtn) prevBtn.addEventListener("click", function () { goTo(current - 1); restartAutoplay(); });
        if (nextBtn) nextBtn.addEventListener("click", function () { goTo(current + 1); restartAutoplay(); });

        // Pausa o autoplay quando o mouse está sobre o carrossel
        root.addEventListener("mouseenter", stopAutoplay);
        root.addEventListener("mouseleave", startAutoplay);

        // Suporte a arraste/swipe (touch e mouse)
        var startX = null;
        track.addEventListener("touchstart", function (e) { startX = e.touches[0].clientX; }, { passive: true });
        track.addEventListener("touchend", function (e) {
            if (startX === null) return;
            var diff = e.changedTouches[0].clientX - startX;
            if (Math.abs(diff) > 40) {
                goTo(diff > 0 ? current - 1 : current + 1);
                restartAutoplay();
            }
            startX = null;
        });

        // Suporte a teclado (setas) quando o carrossel está com foco
        root.setAttribute("tabindex", "0");
        root.addEventListener("keydown", function (e) {
            if (e.key === "ArrowLeft") { goTo(current - 1); restartAutoplay(); }
            if (e.key === "ArrowRight") { goTo(current + 1); restartAutoplay(); }
        });

        render();
        startAutoplay();
    }

    document.addEventListener("DOMContentLoaded", function () {
        document.querySelectorAll(".mm-carousel").forEach(initCarousel);
    });
})();
