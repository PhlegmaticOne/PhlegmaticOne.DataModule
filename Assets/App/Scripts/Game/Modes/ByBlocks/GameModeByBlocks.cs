using System.Collections.Generic;
using System.Linq;
using App.Scripts.Common.Pools;
using App.Scripts.Game.Features._Common.Services;
using App.Scripts.Game.Features.Blocks.Models;
using App.Scripts.Game.Modes.Base;
using Assets.App.Scripts.Game.Features.Blocks.Models;
using PhlegmaticOne.FruitNinja.Shared;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace App.Scripts.Game.Modes.ByBlocks
{
    public class GameModeByBlocks : GameModeBase<GameDataByBlocks>
    {
        [SerializeField] private HorizontalLayoutGroup _group;
        [SerializeField] private GameModeTargetBlockView _prefab;
        
        private ISessionService _sessionService;
        private List<(BlockType, int)> _slicesCount;

        [Inject]
        private void Construct(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        
        public override GameModeType GameModeType => GameModeType.ByBlocks;
        public override bool IsBreakGame => true;
        public override bool IsLocalCompleted()
        {
            for (var i = 0; i < _slicesCount.Count; i++)
            {
                var (blockType, count) = _slicesCount[i];
                var slicesCount = _sessionService.GetSlicesCount(blockType);

                if (slicesCount < count)
                {
                    return false;
                }
            }

            return true;
        }

        public override GameEndStateViewModel BuildGameEndStateViewModel(PlayersSyncMessage playersSyncMessage)
        {
            var viewModel = new GameEndStateViewModel(PlayerService)
            {
                IsDraw = playersSyncMessage.First.Score == playersSyncMessage.Second.Score
            };

            var winner = playersSyncMessage.First.Score > playersSyncMessage.Second.Score
                ? playersSyncMessage.First
                : playersSyncMessage.Second;
            
            var loser = playersSyncMessage.First.Score < playersSyncMessage.Second.Score
                ? playersSyncMessage.First
                : playersSyncMessage.Second;

            return viewModel.SetWinner(winner).SetLoser(loser);
        }

        protected override void ApplyReceivedData()
        {
            _group.gameObject.SetActive(true);
            
            _slicesCount = GameDataBase.BlocksData
                .Select(x => (BlockTypesMapper.MapFromSharedBlockType(x.Key), x.Value))
                .ToList();

            foreach (var (blockType, count) in _slicesCount)
            {
                var view = Instantiate(_prefab, _group.transform);
                view.Setup(blockType, count);
            }
        }
    }
}