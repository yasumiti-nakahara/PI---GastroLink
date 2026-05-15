const mongoose = require('mongoose');

const UsuarioSchema = new mongoose.Schema({
    tipo: { 
        type: String, 
        required: true, 
        enum: ['restaurante', 'influencer'] 
    },
    nome: { type: String, required: true },
    nicho: { type: String, required: true },
    localizacao: { type: String },
    instagram_url: { type: String },
    seguidores: { type: Number, default: 0 }
}, { timestamps: true }); // timestamps cria automaticamente 'createdAt' e 'updatedAt'

module.exports = mongoose.model('Usuario', UsuarioSchema);