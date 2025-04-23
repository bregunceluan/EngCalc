# EngCalc API



🚀 **Uma API para Engenharia Civil**

Essa é uma API que pública implementa algumas funcionalidades de apoio para a profissionais da indústria AEC (Architecture, Engineering, and Construction).

---

## 📌 Objetivo

Objetivo desse projeto é construir uma API aberta, prática e acessível para profissionais, estudantes e desenvolvedores da área de engenharia civil. 

A proposta é que juntamente com a comunidade, sejam adicionadas novas features, tornando a api cada vez mais completa. Atualmente, as seguintes funcionalidades estão implementadas ou em desenvolvimento:

Funcionalidades da API:
- [x] Dimesionamento seções transversais submetidas ao cisalhamento, flexão e torção.
- [x] Material concreto.
- [ ] Flexão composta/obliqua de pilares
- [ ] Cálculos para Alvenaria Estrutural
- [ ] Cálculos para estruturas Metálicas

Docs:
- [ ] Implementar frontend da documentação

---

## 🧪 Testando a API
A API pode ser testada de três formas: em ambiente local, via Docker, ou pela versão online.


### Versão Online
Está disponível uma versão online sem restrições de [CORS](https://pt.wikipedia.org/wiki/Cross-origin_resource_sharing), que permite testar a API diretamente via interface gráfica ou utilizando requisições HTTP.

🔗 Acesse o API Tester em: [EngCalc API Tester](https://engcalc-api.devluan.com/)

### Local
Clone o repositório, e navegue ate a pasta da api.
```sh
cd engcalc\src\engcalc.api\
```

Então dê run na Api. (Certifique que você possua o dotnet 8.0 instalado)
```sh
dotnet run
```

### Docker
Você pode também rodar a api diretamente via docker. Para isso faça um clone do repositório e navegue ate a pasta:
```sh
cd engcalc
```
Faça o build da imagem da EngCalc API
```sh
docker build -f docker/Dockerfile -t engcalc-api .
```
Rode a api via docker
```sh
docker run -p 8080:8080 engcalc-api
```
Após isso, a API estará disponível em: http://localhost:8080

---

## 📚 Documentação

A documentação completa da API será implementada futuramente aqui mesmo no repositório, e atualmente pode ser encontrada diretamente na plataforma [EngCalc API Docs](https://engcalc-api.devluan.com/docs)

---

## 🤝 Contribuindo

Se você é engenheiro, desenvolvedor ou entusiasta e deseja colaborar com o projeto: Clone o repositório, implemente novas funcionalidades e envie o pull request!

Note que todas as funcionalidades implementadas na API possuem testes automatizados, garantindo o pleno funcionamento da ferramenta e maior confiabilidade nos resultados.

Ao contribuir com novas funcionalidades, é importante que elas sejam acompanhadas dos respectivos testes, assegurando a manutenção da estabilidade e qualidade do projeto.

Todos os tipos de contribuição são bem-vindos!

---

## 📄 Licença

Este projeto está sob a licença GNU License. Veja o arquivo [LICENSE](./LICENSE) para mais detalhes.

---

## ✉️ Contato

Fique à vontade para entrar em contato para dúvidas, sugestões ou parcerias:

- [Luan Bregunce]
- [https://www.linkedin.com/in/luanbregunce/]

---

**EngCalc API** — Calculado para comunidade AEC.
