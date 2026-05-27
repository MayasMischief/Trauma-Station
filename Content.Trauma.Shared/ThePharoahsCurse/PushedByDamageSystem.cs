using Content.Shared.Weapons.Melee.Events;

namespace Content.Trauma.Shared.ThePharoahsCurse;

/// <summary>
/// This handles <see cref="PushedByDamageComponent"/>
/// </summary>
public sealed partial class PushedByDamageSystem : EntitySystem
{
    public override void Initialize()
    {
        SubscribeLocalEvent<PushedByDamageComponent, MeleeHitEvent>(OnMeleeHit);
        //SubscribeLocalEvent<PushedByDamageComponent, ProjectileHitEvent>(OnProjectileHit);
        /// no hitscans they're slop
    }

    private void OnMeleeHit(Entity<PushedByDamageComponent> ent, ref MeleeHitEvent args)
    {
        Log.Debug($"{args}");
    }
}