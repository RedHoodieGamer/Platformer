using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class EnemyManager
    {
        private List<Enemy> enemies;

        public EnemyManager(List<Enemy> enemy)
        {
            enemies = enemy;
        }

        public void Update()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
            }
        }

    }
}
