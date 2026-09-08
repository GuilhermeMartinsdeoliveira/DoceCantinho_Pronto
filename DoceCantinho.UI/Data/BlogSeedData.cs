using System;
using System.Collections.Generic;
using DoceCantinho.UI.Models;
using static DoceCantinho.UI.Models.BlogContentBlock;

namespace DoceCantinho.UI.Data
{
    /// <summary>
    /// Fonte de dados do Blog. Hoje os posts vivem em memória (sem tabela no banco),
    /// o que já entrega o Blog funcionando de ponta a ponta. Quando quiser migrar para
    /// o banco de dados, basta criar uma entidade "BlogPost" (Domain), um repositório
    /// (Infrastructure) e um serviço (Application) — o Controller e as Views não precisam mudar,
    /// pois já trabalham em cima do BlogPostViewModel.
    /// </summary>
    public static class BlogSeedData
    {
        public static List<BlogPostViewModel> GetPosts()
        {
            return new List<BlogPostViewModel>
            {
                new BlogPostViewModel
                {
                    Slug = "segredos-do-brigadeiro-gourmet-perfeito",
                    Title = "Os segredos do brigadeiro gourmet perfeito",
                    Excerpt = "Textura de ganache, brilho de vitrine e aquele ponto certo na colher: descubra as técnicas que separam um brigadeiro caseiro de um brigadeiro gourmet de verdade.",
                    CoverImageUrl = "https://images.unsplash.com/photo-1548907040-4baa419e6c88?w=1400&h=800&fit=crop&auto=format",
                    Category = "Receitas",
                    Tags = new List<string> { "brigadeiro", "chocolate", "técnicas", "confeitaria" },
                    PublishedAt = new DateTime(2026, 7, 2),
                    AuthorName = "Maria Silva",
                    AuthorRole = "Confeiteira-chefe",
                   AuthorAvatar = "https://images.unsplash.com/photo-1583394838336-acd977736f90?w=100&h=100&fit=crop&auto=format",
                    AuthorBio = "Maria lidera a cozinha do Doce Cantinho há mais de 12 anos e é apaixonada por transformar receitas clássicas em experiências gourmet.",
                    Featured = true,
                    Content = new List<BlogContentBlock>
                    {
                        P("Poucos doces são tão brasileiros quanto o brigadeiro — e poucos geram tanta dúvida na hora de acertar o ponto. Neste guia, vamos além da receita básica e mostramos o que realmente muda o resultado final: dos ingredientes ao tempo exato de panela."),
                        H("Por que nem todo brigadeiro é gourmet"),
                        P("A diferença entre um brigadeiro comum e um brigadeiro gourmet não está em um ingrediente secreto e mágico, mas na soma de pequenos cuidados: qualidade do chocolate, proporção de gordura, ponto de cocção e, principalmente, o tempo de descanso antes de enrolar."),
                        P("Um erro comum é usar apenas achocolatado em pó. Ele até funciona, mas resulta em um doce mais doce e menos encorpado. Chocolate em barra fracionado ou cacau em pó de boa qualidade dão profundidade de sabor e aquela cor mais escura e elegante."),
                        H("Os quatro pilares da textura perfeita"),
                        Ul(
                            "Leite condensado de qualidade — prefira marcas com maior teor de sólidos de leite.",
                            "Manteiga sem sal, adicionada em temperatura ambiente para emulsionar melhor.",
                            "Chocolate fracionado ou cacau 50% cacau, nunca o achocolatado puro.",
                            "Fogo baixo e mexendo sempre — brigadeiro não se faz com pressa."
                        ),
                        Tip("Teste do prato: arraste a colher no fundo da panela. Se o caminho aberto demorar 2-3 segundos para se fechar, o ponto está certo para enrolar."),
                        H("O passo a passo que a gente usa na cozinha"),
                        P("Derreta a manteiga em fogo baixo, adicione o leite condensado e o chocolate picado. Mexa sem parar com uma espátula de silicone, sempre no mesmo sentido, raspando as laterais e o fundo da panela para não empelotar nem grudar."),
                        P("Quando a mistura começar a desgrudar do fundo da panela e ganhar brilho, conte mais 60 segundos mexendo e desligue o fogo. Esse último minuto é o que garante a casquinha levemente firme por fora e o interior cremoso."),
                        Quote("O segredo não é a receita — é a paciência. Brigadeiro pressa vira doce de colher.", "Maria Silva"),
                        H("Deixe descansar antes de enrolar"),
                        P("Transfira o brigadeiro para um refratário untado, cubra com plástico filme encostando na superfície (para não formar película) e leve à geladeira por, no mínimo, 2 horas. Esse descanso é o que permite enrolar bolinhas lisas, sem rachar."),
                        Img("https://images.unsplash.com/photo-1481391319762-47dff72954d9?w=1200&h=700&fit=crop&auto=format", "Brigadeiros gourmet finalizados e prontos para a granulada."),
                        H("Como conservar e transportar"),
                        P("Depois de enrolados, os brigadeiros aguentam até 5 dias refrigerados em pote fechado. Para eventos, monte as forminhas só algumas horas antes — a granulada perde a crocância se ficar tempo demais em contato com a umidade da geladeira."),
                        Hr(),
                        P("Gostou dessas dicas? No Doce Cantinho, cada brigadeiro gourmet é enrolado à mão seguindo exatamente esse processo. Confira nossa loja e monte a sua caixa personalizada.")
                    }
                },

                new BlogPostViewModel
                {
                    Slug = "guia-completo-bolo-de-casamento",
                    Title = "Guia completo para escolher o bolo de casamento",
                    Excerpt = "Sabor, tamanho, decoração e cronograma de encomenda: tudo o que um casal precisa saber antes de fechar o bolo do grande dia.",
                    CoverImageUrl = "https://images.unsplash.com/photo-1519654793190-2301a5783b74?w=1400&h=800&fit=crop&auto=format",
                    Category = "Casamentos",
                    Tags = new List<string> { "casamento", "bolo", "planejamento", "eventos" },
                    PublishedAt = new DateTime(2026, 6, 18),
                    AuthorName = "João Santos",
                    AuthorRole = "Confeiteiro artesanal",
                    AuthorAvatar = "https://f5.folha.uol.com.br/voceviu/2025/04/quem-e-o-confeiteiro-que-virou-fenomeno-no-tiktok-mostrando-sua-rotina-em-uma-padaria.shtml",
                    AuthorBio = "João é especialista em bolos cenográficos e já assinou mais de 300 bolos de casamento no Doce Cantinho.",
                    Featured = false,
                    Content = new List<BlogContentBlock>
                    {
                        P("O bolo é um dos poucos elementos do casamento que os convidados literalmente saboreiam — por isso merece uma atenção especial no planejamento. Reunimos aqui o roteiro que usamos com todos os nossos noivos."),
                        H("Quando começar a pensar no bolo"),
                        P("O ideal é fechar o fornecedor entre 4 e 6 meses antes da data, principalmente em alta temporada (outubro a dezembro e abril a junho). Isso dá tempo para a prova de sabores, ajustes de design e para garantir a agenda da confeitaria."),
                        H("Quantas pessoas o bolo precisa atender"),
                        P("Regra prática: calcule uma fatia por convidado confirmado, mais uma margem de 10% para recepção e fotos. Bolos cenográficos (com andares decorativos, mas menos massa real) são uma ótima opção para reduzir custo sem perder o impacto visual."),
                        Ul(
                            "Até 50 convidados: 2 andares costuma ser suficiente.",
                            "50 a 120 convidados: 3 andares, misturando sabores.",
                            "Acima de 120 convidados: 3-4 andares ou bolo cenográfico + bolo de corte reserva."
                        ),
                        H("Sabores: agrade a maioria sem perder personalidade"),
                        P("Recomendamos sempre variar os sabores por andar — um mais clássico (baunilha com doce de leite, por exemplo) e um mais autoral (como frutas vermelhas com chocolate belga). Assim, todo perfil de convidado encontra algo de que gosta."),
                        Tip("Marque a degustação com pelo menos 2 opções de recheio e leve a pessoa que vai pagar a conta — decisões de última hora custam caro."),
                        H("Decoração: do minimalista ao cenográfico"),
                        P("As tendências recentes têm caminhado para bolos mais texturizados — com efeito de pintura à mão, drapeados de pasta americana e flores naturais ou de açúcar. Fuja de elementos que não combinam com a paleta de cores da decoração geral do evento."),
                        Img("https://images.unsplash.com/photo-1622551683003-8b6d1c3c5f1a?w=1200&h=700&fit=crop&auto=format", "Bolo de casamento em três andares com flores naturais."),
                        H("Logística no dia do evento"),
                        P("Combine com antecedência o horário de entrega e montagem no local — bolos com muitos andares geralmente são montados no próprio salão para reduzir o risco de transporte. Pergunte também sobre climatização do ambiente, já que calor excessivo pode derreter coberturas de manteiga."),
                        Quote("Um bom bolo de casamento não é só bonito — ele precisa sobreviver ao calor do salão, ao corte na frente de todo mundo e ainda estar delicioso.", "João Santos"),
                        H("Perguntas para fazer ao seu confeiteiro"),
                        Ul(
                            "O valor já inclui entrega, montagem e suporte estrutural?",
                            "Existe taxa de degustação e ela é descontada do valor final?",
                            "Qual o prazo limite para alterar número de convidados?",
                            "Como funciona em caso de restrição alimentar (sem lactose, sem glúten)?"
                        ),
                        Hr(),
                        P("No Doce Cantinho, cada bolo de casamento é um projeto único, construído junto com o casal desde a primeira consulta. Fale com a nossa equipe e agende sua degustação.")
                    }
                },

                new BlogPostViewModel
                {
                    Slug = "tipos-de-chocolate-o-que-muda-no-sabor",
                    Title = "Tipos de chocolate: o que realmente muda no sabor",
                    Excerpt = "Amargo, ao leite, branco, ruby e chocolate fracionado: entenda as diferenças de composição e quando usar cada um nas suas receitas.",
                    CoverImageUrl = "https://images.unsplash.com/photo-1511381939415-e44015466834?w=1400&h=800&fit=crop&auto=format",
                    Category = "Confeitaria",
                    Tags = new List<string> { "chocolate", "ingredientes", "curiosidades" },
                    PublishedAt = new DateTime(2026, 5, 27),
                    AuthorName = "Maria Silva",
                    AuthorRole = "Confeiteira-chefe",
                    AuthorAvatar = "https://f5.folha.uol.com.br/voceviu/2025/04/quem-e-o-confeiteiro-que-virou-fenomeno-no-tiktok-mostrando-sua-rotina-em-uma-padaria.shtml",
                    AuthorBio = "Maria lidera a cozinha do Doce Cantinho há mais de 12 anos e é apaixonada por transformar receitas clássicas em experiências gourmet.",
                    Featured = false,
                    Content = new List<BlogContentBlock>
                    {
                        P("Chocolate não é só chocolate. A porcentagem de cacau, a presença de leite e a forma de processamento mudam completamente o sabor, a textura e até a forma correta de derreter cada tipo. Vamos destrinchar isso."),
                        H("Chocolate amargo (ou meio amargo)"),
                        P("Concentra a maior porcentagem de sólidos de cacau, geralmente entre 50% e 90%. Quanto maior o percentual, mais intenso e menos doce. É a escolha certa para ganaches estruturadas, coberturas espelhadas e para equilibrar recheios muito doces."),
                        H("Chocolate ao leite"),
                        P("Combina sólidos de cacau com leite em pó e mais açúcar, resultando em sabor mais suave e cremoso. É o mais popular em trufas e bombons, mas derrete e queima com mais facilidade — exige temperatura mais baixa no banho-maria."),
                        H("Chocolate branco"),
                        P("Tecnicamente não contém sólidos de cacau, apenas manteiga de cacau, leite e açúcar. Por isso tem sabor mais amanteigado e menos amargor. Funciona muito bem combinado com frutas ácidas, como maracujá e frutas vermelhas, que equilibram o dulçor."),
                        H("Chocolate ruby"),
                        P("O mais recente da família — feito a partir de um tipo específico de fava de cacau que naturalmente resulta em coloração rosada e notas frutadas, sem qualquer corante artificial. É uma ótima opção decorativa para bolos com apelo visual moderno."),
                        Img("https://images.unsplash.com/photo-1606313564200-e75d5e30476c?w=1200&h=700&fit=crop&auto=format", "Diferentes tipos de chocolate em barra: amargo, ao leite e branco."),
                        H("Chocolate fracionado x chocolate nobre (fino)"),
                        P("O fracionado (também chamado de \"hidrogenado\") substitui parte da manteiga de cacau por outras gorduras vegetais, o que facilita o derretimento e dispensa a temperagem — ideal para o dia a dia e para quem está começando. Já o chocolate nobre exige temperagem (processo de aquecer e resfriar em temperaturas específicas) para garantir brilho e quebra crocante, mas entrega um resultado sensorial muito superior."),
                        Tip("Regra prática de temperagem para chocolate amargo: aqueça até 45-50°C, resfrie até 27-28°C e volte a aquecer até 31-32°C antes de usar."),
                        H("Como escolher o chocolate certo para a sua receita"),
                        Ul(
                            "Cobertura brilhante e crocante → chocolate nobre temperado.",
                            "Facilidade no dia a dia, sem equipamento especial → chocolate fracionado.",
                            "Ganache firme para recheio → chocolate amargo 50-60%.",
                            "Decoração delicada e colorida → chocolate branco ou ruby."
                        ),
                        Hr(),
                        P("Na nossa vitrine, cada produto informa qual tipo de chocolate foi utilizado — porque acreditamos que ingrediente bom é a base de qualquer doce memorável.")
                    }
                },

                new BlogPostViewModel
                {
                    Slug = "bastidores-nossa-cozinha-de-madrugada",
                    Title = "Bastidores: um dia na nossa cozinha antes do amanhecer",
                    Excerpt = "Às 4h da manhã, enquanto a cidade ainda dorme, o forno do Doce Cantinho já está ligado. Entenda a rotina por trás de cada doce que chega até você.",
                    CoverImageUrl = "https://images.unsplash.com/photo-1517686469429-8bdb88b9f907?w=1400&h=800&fit=crop&auto=format",
                    Category = "Bastidores",
                    Tags = new List<string> { "bastidores", "rotina", "artesanal", "equipe" },
                    PublishedAt = new DateTime(2026, 5, 5),
                    AuthorName = "Ana Oliveira",
                    AuthorRole = "Gerente de produção",
                    AuthorAvatar = "https://f5.folha.uol.com.br/voceviu/2025/04/quem-e-o-confeiteiro-que-virou-fenomeno-no-tiktok-mostrando-sua-rotina-em-uma-padaria.shtml",
                    AuthorBio = "Ana coordena a produção diária do Doce Cantinho, garantindo que cada doce saia da cozinha com o mesmo padrão de qualidade há mais de 8 anos.",
                    Featured = false,
                    Content = new List<BlogContentBlock>
                    {
                        P("Tem gente que acha que confeitaria é só sobre o produto final bonito na vitrine. Quem trabalha na cozinha sabe que a história começa muito antes — geralmente enquanto a cidade ainda está dormindo."),
                        H("4h da manhã: a cozinha acorda primeiro"),
                        P("Nossa equipe chega bem antes do amanhecer para preparar as massas que precisam de tempo de descanso, como as bases de bolo e as massas folhadas. É nesse horário, com a cozinha ainda silenciosa, que conseguimos dar atenção total a cada detalhe técnico."),
                        H("A escolha dos ingredientes do dia"),
                        P("Frutas frescas, ovos e laticínios chegam diariamente de fornecedores locais que conhecemos pelo nome. Antes de qualquer receita começar, cada lote passa por uma checagem visual e de temperatura — padrão que não abrimos mão, mesmo nos dias de maior movimento."),
                        Img("https://images.unsplash.com/photo-1509440159596-0249088772ff?w=1200&h=700&fit=crop&auto=format", "Ingredientes frescos organizados na bancada antes do início da produção."),
                        H("O ritual da prova de qualidade"),
                        P("Cada nova fornada passa pelo que chamamos internamente de \"prova cega\": um confeiteiro que não participou daquela receita específica experimenta o doce e avalia textura, doçura e equilíbrio de sabor, sem saber qual receita está testando. Só depois de aprovado o produto vai para a vitrine."),
                        Quote("Não existe atalho para um doce bom. Existe rotina, repetição e gente que se importa de verdade com o que está fazendo.", "Ana Oliveira"),
                        H("Como cuidamos do desperdício"),
                        Ul(
                            "Sobras de massa de bolo viram a base de trufas e brigadeiros do dia seguinte.",
                            "Cascas de frutas cítricas são usadas em raspas para aromatizar cremes.",
                            "Produção é planejada com base no histórico de vendas, reduzindo excedentes."
                        ),
                        H("O que você vê — e o que não vê — na vitrine"),
                        P("Quando um doce chega até a sua mesa, ele já passou por pelo menos quatro pares de mãos: quem prepara a massa, quem monta, quem decora e quem faz o controle de qualidade final. É esse cuidado em cadeia que buscamos manter em cada pedido, do menor brigadeiro ao maior bolo de casamento."),
                        Tip("Curioso para ver a produção ao vivo? Confira o carrossel na nossa página inicial — incluímos um vídeo direto da nossa cozinha."),
                        Hr(),
                        P("Obrigado por fazer parte dessa rotina com a gente. Cada encomenda sua ajuda a manter viva essa tradição artesanal.")
                    }
                },

                new BlogPostViewModel
                {
                    Slug = "embalagens-sustentaveis-doce-cantinho",
                    Title = "Como estamos tornando nossas embalagens mais sustentáveis",
                    Excerpt = "Trocamos plástico por papel reciclado, repensamos o tamanho das caixas e criamos um programa de devolução de embalagens. Veja o que já mudou — e o que vem por aí.",
                    CoverImageUrl = "https://images.unsplash.com/photo-1542601906990-b4d3fb778b09?w=1400&h=800&fit=crop&auto=format",
                    Category = "Sustentabilidade",
                    Tags = new List<string> { "sustentabilidade", "embalagens", "meio ambiente" },
                    PublishedAt = new DateTime(2026, 4, 14),
                    AuthorName = "João Santos",
                    AuthorRole = "Confeiteiro artesanal",
                    AuthorAvatar = "https://f5.folha.uol.com.br/voceviu/2025/04/quem-e-o-confeiteiro-que-virou-fenomeno-no-tiktok-mostrando-sua-rotina-em-uma-padaria.shtml",
                    AuthorBio = "João é especialista em bolos cenográficos e já assinou mais de 300 bolos de casamento no Doce Cantinho.",
                    Featured = false,
                    Content = new List<BlogContentBlock>
                    {
                        P("Doce bom não pode custar caro para o planeta. Nos últimos dois anos, revisamos praticamente toda a nossa cadeia de embalagens — e queremos compartilhar o processo, os aprendizados e o que ainda estamos testando."),
                        H("De onde partimos"),
                        P("Até 2024, usávamos caixas plásticas transparentes para praticamente todos os produtos — práticas, mas com alto impacto ambiental e nenhuma possibilidade real de reaproveitamento pelo cliente."),
                        H("O que já mudamos"),
                        Ul(
                            "Caixas de papel kraft certificado, produzido a partir de manejo florestal responsável.",
                            "Forminhas de brigadeiro em papel biodegradável, substituindo o plástico.",
                            "Redução de 30% no volume médio das embalagens, ajustando o tamanho ao produto real.",
                            "Fitas e etiquetas impressas com tinta à base de água."
                        ),
                        Img("https://images.unsplash.com/photo-1607083206968-13611e3d76db?w=1200&h=700&fit=crop&auto=format", "Caixas de papel kraft usadas atualmente nas encomendas do Doce Cantinho."),
                        H("O programa de devolução de embalagens"),
                        P("Clientes que devolvem as caixas rígidas (usadas em bolos e tortas) em boas condições recebem um desconto na próxima compra. As caixas retornam para higienização e reutilização, reduzindo o volume de material descartado."),
                        Tip("Quer participar? É só trazer a caixa na loja física ou combinar a devolução com o entregador na próxima encomenda."),
                        H("Os desafios que ainda estamos resolvendo"),
                        P("Nem tudo é simples: embalagens sustentáveis para transporte de bolos com cobertura de chantilly, por exemplo, ainda exigem alguma camada de proteção plástica para evitar contato direto — e seguimos testando alternativas compostáveis que aguentem transporte sem comprometer a decoração."),
                        Quote("Sustentabilidade não é um selo na caixa. É uma lista de decisões pequenas, repetidas todos os dias.", "João Santos"),
                        H("Próximos passos"),
                        P("Para 2027, nosso objetivo é eliminar por completo o plástico de uso único das embalagens de brigadeiros e trufas, e lançar um programa piloto de coleta de resíduos orgânicos da produção com uma cooperativa parceira."),
                        Hr(),
                        P("Se você tem sugestões sobre embalagens ou quer saber mais sobre nossas iniciativas, fale com a gente pela página de contato.")
                    }
                },

                new BlogPostViewModel
                {
                    Slug = "como-conservar-doces-artesanais-em-casa",
                    Title = "Como conservar doces artesanais em casa (sem perder o sabor)",
                    Excerpt = "Cada tipo de doce pede um cuidado diferente na hora de guardar. Veja o guia rápido para manter bolos, trufas, macarons e tortas com a mesma qualidade do primeiro dia.",
                    CoverImageUrl = "https://images.unsplash.com/photo-1488477181946-6428a0291777?w=1400&h=800&fit=crop&auto=format",
                    Category = "Dicas",
                    Tags = new List<string> { "conservação", "dicas", "geladeira", "validade" },
                    PublishedAt = new DateTime(2026, 3, 22),
                    AuthorName = "Maria Silva",
                    AuthorRole = "Confeiteira-chefe",
                    AuthorAvatar = "https://f5.folha.uol.com.br/voceviu/2025/04/quem-e-o-confeiteiro-que-virou-fenomeno-no-tiktok-mostrando-sua-rotina-em-uma-padaria.shtml",
                    AuthorBio = "Maria lidera a cozinha do Doce Cantinho há mais de 12 anos e é apaixonada por transformar receitas clássicas em experiências gourmet.",
                    Featured = false,
                    Content = new List<BlogContentBlock>
                    {
                        P("Recebemos essa pergunta quase todos os dias: \"como eu guardo esse doce em casa?\". A resposta muda bastante dependendo do tipo de produto — e guardar errado é a forma mais comum de estragar um doce que chegou perfeito até você."),
                        H("Bolos com recheio de chantilly ou frutas frescas"),
                        P("Precisam de geladeira sempre. Mantenha em recipiente fechado ou coberto com filme plástico para não pegar odor de outros alimentos. Consumo ideal em até 3 dias."),
                        H("Bolos com cobertura de chocolate ou ganache"),
                        P("Podem ficar em temperatura ambiente (longe de luz solar direta e calor) por até 2 dias, ou na geladeira por até 5 dias. Antes de servir, deixe descansar 20-30 minutos fora da geladeira para o chocolate voltar à textura ideal."),
                        H("Brigadeiros, trufas e docinhos enrolados"),
                        P("Vida útil de até 5 dias refrigerados, em pote fechado. Evite empilhar sem forminhas — a granulada e as coberturas se colam com facilidade."),
                        H("Macarons"),
                        P("São os mais sensíveis à umidade. Guarde sempre na geladeira, em recipiente hermético, e consuma em até 4 dias. Uma dica de confeitaria: macarons ficam ainda mais gostosos no segundo dia, quando o recheio termina de \"macerar\" a casquinha."),
                        Img("https://images.unsplash.com/photo-1569864358642-9d1684040f43?w=1200&h=700&fit=crop&auto=format", "Macarons coloridos organizados em recipiente hermético."),
                        Tip("Nunca congele doces com chantilly ou claras em neve — a textura desanda completamente ao descongelar."),
                        H("É possível congelar?"),
                        P("Sim, mas só alguns tipos. Massas de bolo puras (sem recheio), tortas de massa amanteigada e brigadeiros sem cobertura aguentam até 2 meses no congelador, bem vedados. Descongele sempre na geladeira, nunca em temperatura ambiente ou no micro-ondas."),
                        Ul(
                            "Massa de bolo pura: até 2 meses congelada.",
                            "Brigadeiro sem granulada: até 1 mês congelado.",
                            "Torta amanteigada sem recheio de creme: até 1 mês congelada."
                        ),
                        H("Resumo rápido"),
                        Quote("Na dúvida, geladeira é sempre mais seguro do que a bancada da cozinha — principalmente em dias quentes."),
                        Hr(),
                        P("Ficou com alguma dúvida sobre como conservar o seu pedido? É só chamar a gente pelo WhatsApp ou pela página de contato que te ajudamos com prazer.")
                    }
                }
            };
        }
    }
}
