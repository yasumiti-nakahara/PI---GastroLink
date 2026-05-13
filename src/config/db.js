const mongoose = require('mongoose');

const conectarBanco = async () => {
    try {
        // Conecta usando a URI do arquivo .env
        await mongoose.connect(process.env.MONGO_URI);
        console.log('✅ MongoDB Conectado com sucesso!');
    } catch (erro) {
        console.error('❌ Erro ao conectar ao MongoDB:', erro.message);
        process.exit(1); // Para a aplicação se o banco falhar
    }
};

module.exports = conectarBanco;