require('dotenv').config(); // Carrega as variáveis do .env
const express = require('express');
const cors = require('cors');
const conectarBanco = require('./config/db');
const rotasApi = require('./routes/api');

const app = express();

// Middlewares
app.use(cors()); // Permite requisições do frontend
app.use(express.json()); // Permite receber dados no formato JSON

// Conectar ao Banco de Dados
conectarBanco();

// Definir as Rotas
app.use('/api', rotasApi);

// Rota de teste simples para ver se o servidor está online
app.get('/', (req, res) => {
    res.send('API do App de Influencers rodando! 🚀');
});

// Iniciar o Servidor
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`🚀 Servidor rodando na porta ${PORT}`);
});