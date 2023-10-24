using UnityEngine;

namespace App.Scripts.Game.Features.Particles.Factory.Data {
    public struct ParticlesFactoryData {
        public ParticleSystem Particles { get; set; }
        public Vector3 Position { get; set; }
        public Color Color { get; set; }
    }
}