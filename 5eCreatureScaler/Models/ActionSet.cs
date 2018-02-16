// using System.Collections.Generic;
// using System.Linq;

// namespace CreatureScaler.Models
// {
//     public class ActionSet
//     {
//         public IList<Action> Actions
//         {
//             get;
//             set;
//         }

//         public IList<Attack> Attacks
//         {
//             get;
//             set;
//         }

//         public IEnumerable<IGrouping<int, Action>> GetMultiAttack()
//         {
//             var obj =  Actions.SelectMany(f => f.MultiGroups.Select(m => new 
//             {
//                 Group = m,
//                 Action = f,
//             }))
//             .GroupBy(f => f.Group, f => f.Action);

//             return obj;
//         }
//     }
// }
