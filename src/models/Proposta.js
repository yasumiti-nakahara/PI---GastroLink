const mongoose = require('mongoose');

const PropostaSchema = new mongoose.Schema({
    restauranteId: { 
        type: mongoose.Schema.Types.ObjectId, 
        ref: 'Usuario', 
        required: true 
    },
    influencerId: { 
        type: mongoose.Schema.Types.ObjectId, 
        ref: 'Usuario', 
        required: true 
    },
    mensagem: { type: String, required: true },
    status: { 
        type: String, 
        default: 'pendente',
        enum: ['pendente', 'aceita', 'recusada'] 
    }
}, { timestamps: true });

module.exports = mongoose.model('Proposta', PropostaSchema);